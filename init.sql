-- Tabel roles
CREATE TABLE IF NOT EXISTS roles (
    id   SERIAL PRIMARY KEY,
    nama VARCHAR(20) NOT NULL UNIQUE
);


-- Data awal role
INSERT INTO roles (nama) VALUES ('peserta'), ('coach'), ('ortu')
ON CONFLICT (nama) DO NOTHING;

-- Tabel users
CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NULL,
    password_hash VARCHAR(255) NOT NULL,
    nama VARCHAR(100) NOT NULL,
    role_id INT NOT NULL REFERENCES roles(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel profiles
CREATE TABLE IF NOT EXISTS profiles (
    id SERIAL PRIMARY KEY,
    user_id INT UNIQUE NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel peserta_details
CREATE TABLE IF NOT EXISTS peserta_details (
    user_id INT PRIMARY KEY REFERENCES users(id) ON DELETE CASCADE,
    kode_peserta VARCHAR(20) UNIQUE NOT NULL
);

-- Tabel kategori_latihan
CREATE TABLE IF NOT EXISTS kategori_latihan (
    id SERIAL PRIMARY KEY,
    nama_latihan VARCHAR(50) NOT NULL UNIQUE
);

-- Tabel status_aktivitas
CREATE TABLE IF NOT EXISTS status_aktivitas (
    id SERIAL PRIMARY KEY,
    nama VARCHAR(30) NOT NULL UNIQUE
);

INSERT INTO status_aktivitas (nama) VALUES ('Menunggu'), ('Disetujui'), ('Revisi')
ON CONFLICT (nama) DO NOTHING;

-- Tabel aktivitas
CREATE TABLE IF NOT EXISTS aktivitas (
    id SERIAL PRIMARY KEY,
    peserta_id  INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    kategori_id INT NOT NULL REFERENCES kategori_latihan(id),
    status_id   INT NOT NULL REFERENCES status_aktivitas(id) DEFAULT 1,
    nama VARCHAR(100) NOT NULL,
    durasi INT NOT NULL CHECK (durasi > 0),
    tanggal DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel feedback_aktivitas
CREATE TABLE IF NOT EXISTS feedback_aktivitas (
    id SERIAL PRIMARY KEY,
    aktivitas_id INT  NOT NULL REFERENCES aktivitas(id) ON DELETE CASCADE,
    coach_id INT  NOT NULL REFERENCES profiles(id),
    feedback TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS peserta_coach (
    id SERIAL PRIMARY KEY,
    peserta_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    coach_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    assigned_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(peserta_id),
    CONSTRAINT chk_no_self_assign CHECK (peserta_id <> coach_id)
);

CREATE TABLE IF NOT EXISTS orang_tua_peserta (
    id SERIAL PRIMARY KEY,
    ortu_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    peserta_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    UNIQUE(ortu_id, peserta_id),
    CONSTRAINT chk_no_self_parent CHECK (ortu_id <> peserta_id)
);

-- Function
CREATE OR REPLACE FUNCTION set_updated_timestamp()
RETURNS TRIGGER 
language plpgsql
AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$;

-- Trigger
CREATE TRIGGER trg_aktivitas_updated_at
BEFORE UPDATE ON aktivitas
FOR EACH ROW EXECUTE FUNCTION set_updated_timestamp();

CREATE TRIGGER trg_feedback_updated_at
BEFORE UPDATE ON feedback_aktivitas
FOR EACH ROW EXECUTE FUNCTION set_updated_timestamp();

CREATE TRIGGER trg_profiles_updated_at
BEFORE UPDATE ON profiles
FOR EACH ROW EXECUTE FUNCTION set_updated_timestamp();


-- ===========================================================================
--  IMPLEMENTASI BAB III  (objek tambahan: View, Function, Procedure, Trigger)
-- ===========================================================================

-- ---------------------------------------------------------------------------
-- 3.4  VIEW  — menyederhanakan query multi-tabel
-- ---------------------------------------------------------------------------
-- View utama: gabungan aktivitas + identitas peserta + kategori + status.
-- Dipakai dashboard peserta/coach/ortu agar tidak menulis JOIN 4 tabel berulang.
CREATE OR REPLACE VIEW v_aktivitas_lengkap AS
SELECT a.id,
       a.peserta_id,
       a.kategori_id,
       a.status_id,
       a.nama,
       a.durasi,
       a.tanggal,
       a.created_at,
       a.updated_at,
       u.nama          AS nama_peserta,
       kl.nama_latihan AS nama_kategori,
       sa.nama         AS nama_status
FROM aktivitas a
JOIN profiles p          ON a.peserta_id = p.id
JOIN users u             ON p.user_id    = u.id
JOIN kategori_latihan kl ON a.kategori_id = kl.id
JOIN status_aktivitas sa ON a.status_id  = sa.id;

-- 3.1  GROUP BY + Agregasi  — HAVING, ROLLUP, CUBE
-- (a) HAVING: kategori dengan total durasi signifikan (> 60 menit) per peserta.
CREATE OR REPLACE VIEW v_rekap_kategori_signifikan AS
SELECT a.peserta_id,
       kl.nama_latihan      AS kategori,
       SUM(a.durasi)        AS total_durasi,
       COUNT(*)             AS jumlah_aktivitas
FROM aktivitas a
JOIN kategori_latihan kl ON a.kategori_id = kl.id
GROUP BY a.peserta_id, kl.nama_latihan
HAVING SUM(a.durasi) > 60;

-- (b) ROLLUP: rekap durasi bertingkat (per kategori → per status → subtotal).
--     Baris dengan kategori/status = NULL adalah baris subtotal/grand-total.
CREATE OR REPLACE FUNCTION rekap_durasi_rollup(p_peserta_id INT)
RETURNS TABLE(kategori TEXT, status TEXT, total_durasi BIGINT)
LANGUAGE sql
AS $$
    SELECT kl.nama_latihan::TEXT,
           sa.nama::TEXT,
           SUM(a.durasi)
    FROM aktivitas a
    JOIN kategori_latihan kl ON a.kategori_id = kl.id
    JOIN status_aktivitas sa ON a.status_id  = sa.id
    WHERE a.peserta_id = p_peserta_id
    GROUP BY ROLLUP (kl.nama_latihan, sa.nama)
    ORDER BY kl.nama_latihan NULLS LAST, sa.nama NULLS LAST;
$$;

-- (c) CUBE: rekap silang kategori x status (semua kombinasi subtotal).
CREATE OR REPLACE VIEW v_rekap_durasi_cube AS
SELECT a.peserta_id,
       kl.nama_latihan AS kategori,
       sa.nama         AS status,
       SUM(a.durasi)   AS total_durasi
FROM aktivitas a
JOIN kategori_latihan kl ON a.kategori_id = kl.id
JOIN status_aktivitas sa ON a.status_id  = sa.id
GROUP BY CUBE (a.peserta_id, kl.nama_latihan, sa.nama);

-- 3.3  SUBQUERY  — IN / EXISTS pada klausa WHERE
-- Peserta yang belum pernah mendapat evaluasi (feedback) dari coach.
CREATE OR REPLACE VIEW v_peserta_belum_dievaluasi AS
SELECT p.id AS peserta_id,
       u.nama AS nama_peserta
FROM profiles p
JOIN users u ON p.user_id = u.id
JOIN roles r ON u.role_id = r.id
WHERE r.nama = 'peserta'
  AND NOT EXISTS (
        SELECT 1
        FROM feedback_aktivitas f
        JOIN aktivitas a ON f.aktivitas_id = a.id
        WHERE a.peserta_id = p.id
  );

-- 3.6  SET OPERATIONS  — UNION / EXCEPT
-- (a) UNION: semua pihak (coach + orang tua) yang terhubung dgn seorang peserta.
CREATE OR REPLACE FUNCTION pihak_terkait_peserta(p_peserta_id INT)
RETURNS TABLE(peran TEXT, nama TEXT)
LANGUAGE sql
AS $$
    SELECT 'Coach'::TEXT, u.nama::TEXT
    FROM peserta_coach pc
    JOIN profiles p ON pc.coach_id = p.id
    JOIN users u    ON p.user_id   = u.id
    WHERE pc.peserta_id = p_peserta_id
    UNION
    SELECT 'Orang Tua'::TEXT, u.nama::TEXT
    FROM orang_tua_peserta otp
    JOIN profiles p ON otp.ortu_id = p.id
    JOIN users u    ON p.user_id   = u.id
    WHERE otp.peserta_id = p_peserta_id;
$$;

-- (b) EXCEPT: peserta yang belum punya coach sama sekali.
CREATE OR REPLACE VIEW v_peserta_tanpa_coach AS
SELECT p.id AS peserta_id
FROM profiles p
JOIN users u ON p.user_id = u.id
JOIN roles r ON u.role_id = r.id
WHERE r.nama = 'peserta'
EXCEPT
SELECT peserta_id FROM peserta_coach;

-- ---------------------------------------------------------------------------
-- 3.7  STORED FUNCTION  — logika bisnis + Control Flow (IF/ELSIF/ELSE, CASE)
-- ---------------------------------------------------------------------------
-- (a) Total durasi latihan yang sudah Disetujui (status_id = 2) milik peserta.
CREATE OR REPLACE FUNCTION hitung_total_durasi(p_peserta_id INT)
RETURNS INT
LANGUAGE plpgsql
AS $$
DECLARE
    v_total INT;
BEGIN
    SELECT COALESCE(SUM(durasi), 0)
      INTO v_total
      FROM aktivitas
     WHERE peserta_id = p_peserta_id
       AND status_id  = 2;          -- hanya yang berstatus 'Disetujui'
    RETURN v_total;
END;
$$;

-- (b) Klasifikasi keaktifan peserta berdasar total durasi (Control Flow IF/ELSIF).
CREATE OR REPLACE FUNCTION level_keaktifan(p_peserta_id INT)
RETURNS TEXT
LANGUAGE plpgsql
AS $$
DECLARE
    v_total INT;
    v_level TEXT;
BEGIN
    v_total := hitung_total_durasi(p_peserta_id);

    IF v_total >= 600 THEN
        v_level := 'Sangat Aktif';
    ELSIF v_total >= 300 THEN
        v_level := 'Aktif';
    ELSIF v_total > 0 THEN
        v_level := 'Cukup';
    ELSE
        v_level := 'Belum Ada Latihan';
    END IF;

    RETURN v_level;
END;
$$;

-- ---------------------------------------------------------------------------
-- 3.8 + 3.9  STORED PROCEDURE + TRANSACTION CONTROL (COMMIT / ROLLBACK)
-- ---------------------------------------------------------------------------
-- Coach memberi feedback sekaligus mengubah status aktivitas dalam satu proses.
-- Jika aktivitas sudah 'Disetujui' (2), seluruh proses dibatalkan (ROLLBACK).
CREATE OR REPLACE PROCEDURE sp_beri_feedback(
    p_aktivitas_id INT,
    p_coach_id     INT,
    p_feedback     TEXT,
    p_status_id    INT
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_status_lama INT;
BEGIN
    -- ambil status aktivitas saat ini
    SELECT status_id INTO v_status_lama
      FROM aktivitas
     WHERE id = p_aktivitas_id;

    -- 1) simpan feedback   2) ubah status — dua operasi sebagai satu kesatuan
    INSERT INTO feedback_aktivitas (aktivitas_id, coach_id, feedback)
    VALUES (p_aktivitas_id, p_coach_id, p_feedback);

    UPDATE aktivitas
       SET status_id = p_status_id
     WHERE id = p_aktivitas_id;

    -- Transaction control: aktivitas yang sudah final ('Disetujui') tidak boleh
    -- diberi feedback lagi → batalkan kedua operasi di atas.
    IF v_status_lama IS NULL OR v_status_lama = 2 THEN
        ROLLBACK;
        RAISE EXCEPTION 'Feedback dibatalkan: aktivitas tidak ditemukan atau sudah Disetujui.';
    ELSE
        COMMIT;
    END IF;
END;
$$;

-- 3.10  TRIGGER Stored Procedure
-- Jika peserta mengubah data latihan (nama/durasi/tanggal/kategori), status
-- otomatis dikembalikan ke 'Menunggu' (1) agar coach mengevaluasi ulang.
-- Perubahan status saja (mis. coach approve) TIDAK memicu reset ini.
CREATE OR REPLACE FUNCTION reset_status_saat_edit()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
    IF NEW.nama        <> OLD.nama
       OR NEW.durasi   <> OLD.durasi
       OR NEW.tanggal  <> OLD.tanggal
       OR NEW.kategori_id <> OLD.kategori_id THEN
        NEW.status_id := 1;          -- kembali ke 'Menunggu'
    END IF;
    RETURN NEW;
END;
$$;

CREATE TRIGGER trg_reset_status_saat_edit
BEFORE UPDATE ON aktivitas
FOR EACH ROW EXECUTE FUNCTION reset_status_saat_edit();