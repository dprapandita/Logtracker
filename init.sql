-- Buat database
-- psql -U postgres -c "CREATE DATABASE logtracker_db;"
-- psql -U postgres -d logtracker_db -f init.sql

-- Tabel roles
CREATE TABLE IF NOT EXISTS roles (
    id SERIAL PRIMARY KEY,
    nama VARCHAR(20) NOT NULL UNIQUE CHECK (nama IN ('peserta', 'coach', 'ortu'))
);

-- Seed roles
INSERT INTO roles (nama) VALUES ('peserta'), ('coach'), ('ortu')
ON CONFLICT (nama) DO NOTHING;

-- Tabel profiles (identitas user)
CREATE TABLE IF NOT EXISTS profiles (
    id SERIAL PRIMARY KEY,
    nama VARCHAR(100) NOT NULL,
    kode_peserta VARCHAR(20) UNIQUE NULL
);

-- Tabel akun_login (kredensial login)
CREATE TABLE IF NOT EXISTS akun_login (
    id SERIAL PRIMARY KEY,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role_id INT NOT NULL REFERENCES roles(id),
    profile_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE
);

-- Tabel aktivitas
CREATE TABLE IF NOT EXISTS aktivitas (
    id SERIAL PRIMARY KEY,
    peserta_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    nama VARCHAR(100) NOT NULL,
    kategori VARCHAR(50) NOT NULL,
    durasi INT NOT NULL,
    tanggal DATE NOT NULL,
    status VARCHAR(30) DEFAULT 'Menunggu' CHECK (status IN ('Menunggu', 'Disetujui', 'Revisi')),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel feedback_aktivitas (catatan dari coach)
CREATE TABLE IF NOT EXISTS feedback_aktivitas (
    id SERIAL PRIMARY KEY,
    aktivitas_id INT NOT NULL REFERENCES aktivitas(id) ON DELETE CASCADE,
    coach_id INT NOT NULL REFERENCES profiles(id),
    feedback TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel peserta_coach (relasi peserta dan coach)
CREATE TABLE IF NOT EXISTS peserta_coach (
    id SERIAL PRIMARY KEY,
    peserta_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    coach_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    UNIQUE(peserta_id)
);

-- Tabel orang_tua_peserta (relasi orang tua dan peserta)
CREATE TABLE IF NOT EXISTS orang_tua_peserta (
    id SERIAL PRIMARY KEY,
    ortu_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    peserta_id INT NOT NULL REFERENCES profiles(id) ON DELETE CASCADE,
    UNIQUE(ortu_id, peserta_id)
);
