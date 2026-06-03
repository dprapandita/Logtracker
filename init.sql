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
    nama VARCHAR(100) NOT NULL,
    kode_peserta VARCHAR(20)  UNIQUE NULL,
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