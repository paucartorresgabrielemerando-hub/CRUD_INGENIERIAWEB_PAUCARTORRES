-- Base de datos: demodb
-- Motor: MySQL 8+
-- Charset/Collation recomendado (coincide con scaffolding EF): utf8mb4 / utf8mb4_0900_ai_ci

CREATE DATABASE IF NOT EXISTS demodb
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_0900_ai_ci;

USE demodb;

-- =========================
-- Tablas maestras existentes
-- =========================

CREATE TABLE IF NOT EXISTS persona_tipo_documento (
  id INT NOT NULL AUTO_INCREMENT,
  codigo VARCHAR(20) NOT NULL,
  descripcion VARCHAR(50) NOT NULL,
  user_create INT NOT NULL,
  user_update INT NULL,
  date_created TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  date_update TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS persona (
  id INT NOT NULL AUTO_INCREMENT,
  id_tipo_documento INT NOT NULL,
  nombres VARCHAR(100) NULL,
  apellido_paterno VARCHAR(100) NULL,
  apellido_materno VARCHAR(100) NULL,
  direccion VARCHAR(300) NULL,
  telefono VARCHAR(30) NULL,
  user_create INT NOT NULL,
  user_update INT NULL,
  date_created TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  date_update TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  INDEX fk_persona_tipo_documento (id_tipo_documento),
  CONSTRAINT fk_persona_tipo_documento
    FOREIGN KEY (id_tipo_documento) REFERENCES persona_tipo_documento (id)
    ON UPDATE RESTRICT
    ON DELETE RESTRICT
) ENGINE=InnoDB;

-- =========================
-- Nuevas tablas dependientes
-- =========================

CREATE TABLE IF NOT EXISTS persona_correo (
  id INT NOT NULL AUTO_INCREMENT,
  id_persona INT NOT NULL,
  correo VARCHAR(150) NOT NULL,
  es_principal TINYINT(1) NOT NULL DEFAULT 0,
  user_create INT NOT NULL,
  user_update INT NULL,
  date_created TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  date_update TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  INDEX ix_persona_correo_id_persona (id_persona),
  CONSTRAINT fk_persona_correo_persona
    FOREIGN KEY (id_persona) REFERENCES persona (id)
    ON UPDATE RESTRICT
    ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS persona_direccion (
  id INT NOT NULL AUTO_INCREMENT,
  id_persona INT NOT NULL,
  tipo VARCHAR(20) NOT NULL,
  direccion VARCHAR(300) NOT NULL,
  ciudad VARCHAR(80) NULL,
  region VARCHAR(80) NULL,
  codigo_postal VARCHAR(15) NULL,
  user_create INT NOT NULL,
  user_update INT NULL,
  date_created TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  date_update TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  INDEX ix_persona_direccion_id_persona (id_persona),
  CONSTRAINT fk_persona_direccion_persona
    FOREIGN KEY (id_persona) REFERENCES persona (id)
    ON UPDATE RESTRICT
    ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS persona_empleo (
  id INT NOT NULL AUTO_INCREMENT,
  id_persona INT NOT NULL,
  empresa VARCHAR(150) NOT NULL,
  cargo VARCHAR(100) NULL,
  fecha_inicio DATE NOT NULL,
  fecha_fin DATE NULL,
  salario DECIMAL(10,2) NULL,
  user_create INT NOT NULL,
  user_update INT NULL,
  date_created TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  date_update TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (id),
  INDEX ix_persona_empleo_id_persona (id_persona),
  CONSTRAINT fk_persona_empleo_persona
    FOREIGN KEY (id_persona) REFERENCES persona (id)
    ON UPDATE RESTRICT
    ON DELETE CASCADE
) ENGINE=InnoDB;

-- =========================
-- Seeds mínimos (opcional)
-- =========================

INSERT INTO persona_tipo_documento (codigo, descripcion, user_create)
SELECT * FROM (
  SELECT 'DNI', 'Documento Nacional', 1
) AS seed
WHERE NOT EXISTS (SELECT 1 FROM persona_tipo_documento WHERE codigo = 'DNI')
LIMIT 1;

