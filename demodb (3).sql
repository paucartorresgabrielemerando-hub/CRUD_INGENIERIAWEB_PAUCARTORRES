-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-02-2026 a las 16:50:18
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `demodb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `id` int(11) NOT NULL,
  `id_tipo_documento` int(11) NOT NULL,
  `nombres` varchar(100) DEFAULT NULL,
  `apellido_paterno` varchar(100) DEFAULT NULL,
  `apellido_materno` varchar(100) DEFAULT NULL,
  `direccion` varchar(300) DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `user_create` int(11) NOT NULL,
  `user_update` int(11) DEFAULT NULL,
  `date_created` timestamp NULL DEFAULT current_timestamp(),
  `date_update` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`id`, `id_tipo_documento`, `nombres`, `apellido_paterno`, `apellido_materno`, `direccion`, `telefono`, `user_create`, `user_update`, `date_created`, `date_update`) VALUES
(1, 1, 'Carlos', 'García', 'Mendoza', 'Av. Larco 123, Lima', '987654321', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(2, 1, 'Ana', 'Martínez', 'López', 'Calle Las Flores 456, Arequipa', '912345678', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(3, 2, 'John', 'Doe', 'Smith', 'Hotel Sheraton Suite 20', '955443322', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(4, 3, 'Hans', 'Müller', 'Schmidt', 'Calle Berlín 789, Miraflores', '900112233', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(5, 1, 'María', 'Rodríguez', 'Pérez', 'Jr. Junín 101, Cusco', '944556677', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(6, 4, 'Elena', 'Vásquez', 'Ruiz', 'Urb. Los Cedros B-12', '933221100', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(7, 5, 'Roberto', 'Sánchez', 'Torres', 'Paseo de la República 5050', '966778899', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(8, 2, 'Linda', 'Johnson', 'Brown', 'Residencial San Felipe G-302', '977889900', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(9, 1, 'Luis', 'Castro', 'Villanueva', 'Malecón Cisneros 150', '922334455', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36'),
(10, 6, 'Ricardo', 'Palma', 'Soriano', 'Calle Libertad 222', '911002233', 1, NULL, '2026-02-27 14:39:36', '2026-02-27 14:39:36');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona_correo`
--

CREATE TABLE `persona_correo` (
  `id` int(11) NOT NULL,
  `id_persona` int(11) NOT NULL,
  `correo` varchar(150) NOT NULL,
  `es_principal` tinyint(1) NOT NULL DEFAULT 0,
  `user_create` int(11) NOT NULL,
  `user_update` int(11) DEFAULT NULL,
  `date_created` timestamp NULL DEFAULT current_timestamp(),
  `date_update` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona_correo`
--

INSERT INTO `persona_correo` (`id`, `id_persona`, `correo`, `es_principal`, `user_create`, `user_update`, `date_created`, `date_update`) VALUES
(1, 1, 'cgarcia@mail.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(2, 1, 'carlos.work@empresa.com', 0, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(3, 2, 'ana.mtz@gmail.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(4, 3, 'john.doe@travel.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(5, 4, 'hans_m@outlook.de', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(6, 5, 'mrodriguez@peru.gob.pe', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(7, 6, 'elena.v@yahoo.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(8, 7, 'rsanchez@corporativo.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(9, 8, 'linda.j@usa.net', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(10, 9, 'lcastro_90@hotmail.com', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44'),
(11, 10, 'rpalma@biblioteca.org', 1, 1, NULL, '2026-02-27 14:39:44', '2026-02-27 14:39:44');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona_direccion`
--

CREATE TABLE `persona_direccion` (
  `id` int(11) NOT NULL,
  `id_persona` int(11) NOT NULL,
  `tipo` varchar(20) NOT NULL,
  `direccion` varchar(300) NOT NULL,
  `ciudad` varchar(80) DEFAULT NULL,
  `region` varchar(80) DEFAULT NULL,
  `codigo_postal` varchar(15) DEFAULT NULL,
  `user_create` int(11) NOT NULL,
  `user_update` int(11) DEFAULT NULL,
  `date_created` timestamp NULL DEFAULT current_timestamp(),
  `date_update` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona_direccion`
--

INSERT INTO `persona_direccion` (`id`, `id_persona`, `tipo`, `direccion`, `ciudad`, `region`, `codigo_postal`, `user_create`, `user_update`, `date_created`, `date_update`) VALUES
(1, 1, 'Hogar', 'Av. Larco 123', 'Lima', 'Lima', '15047', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(2, 1, 'Trabajo', 'Calle Real 400', 'Huancayo', 'Junín', '12001', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(3, 2, 'Hogar', 'Calle Las Flores 456', 'Arequipa', 'Arequipa', '04001', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(4, 3, 'Temporal', 'Av. Pardo 500', 'Lima', 'Lima', '15074', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(5, 5, 'Hogar', 'Jr. Junín 101', 'Cusco', 'Cusco', '08002', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(6, 6, 'Hogar', 'Urb. Los Cedros B-12', 'Trujillo', 'La Libertad', '13001', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(7, 7, 'Oficina', 'Torre Begonias 450', 'Lima', 'Lima', '15021', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(8, 8, 'Hogar', 'Res. San Felipe', 'Lima', 'Lima', '15072', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(9, 9, 'Hogar', 'Malecón Cisneros 150', 'Lima', 'Lima', '15074', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56'),
(10, 10, 'Hogar', 'Calle Libertad 222', 'Iquitos', 'Loreto', '16001', 1, NULL, '2026-02-27 14:39:56', '2026-02-27 14:39:56');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona_empleo`
--

CREATE TABLE `persona_empleo` (
  `id` int(11) NOT NULL,
  `id_persona` int(11) NOT NULL,
  `empresa` varchar(150) NOT NULL,
  `cargo` varchar(100) DEFAULT NULL,
  `fecha_inicio` date NOT NULL,
  `fecha_fin` date DEFAULT NULL,
  `salario` decimal(10,2) DEFAULT NULL,
  `user_create` int(11) NOT NULL,
  `user_update` int(11) DEFAULT NULL,
  `date_created` timestamp NULL DEFAULT current_timestamp(),
  `date_update` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona_empleo`
--

INSERT INTO `persona_empleo` (`id`, `id_persona`, `empresa`, `cargo`, `fecha_inicio`, `fecha_fin`, `salario`, `user_create`, `user_update`, `date_created`, `date_update`) VALUES
(1, 1, 'Tech Solutions SA', 'Analista Senior', '2020-01-15', NULL, 5500.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(2, 2, 'Banco Central', 'Contadora', '2018-05-10', '2022-12-31', 4800.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(3, 3, 'Global Logistics', 'Consultor', '2023-02-01', NULL, 7000.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(4, 4, 'Automotriz Alemana', 'Ingeniero Mecánico', '2015-11-20', '2021-06-30', 6200.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(5, 5, 'Ministerio de Cultura', 'Guía Turístico', '2019-03-01', NULL, 3200.50, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(6, 6, 'Clínica San Pablo', 'Enfermera', '2021-08-15', NULL, 3800.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(7, 7, 'Minera Las Bambas', 'Supervisor de Seguridad', '2017-10-10', NULL, 8500.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(8, 8, 'Embajada de EE.UU.', 'Traductora', '2022-01-05', '2023-12-01', 5000.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(9, 9, 'Supermercados Peruanos', 'Gerente de Tienda', '2016-04-20', NULL, 4500.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03'),
(10, 10, 'Archivo Nacional', 'Historiador', '2010-02-15', NULL, 3000.00, 1, NULL, '2026-02-27 14:40:03', '2026-02-27 14:40:03');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona_tipo_documento`
--

CREATE TABLE `persona_tipo_documento` (
  `id` int(11) NOT NULL,
  `codigo` varchar(20) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `user_create` int(11) NOT NULL,
  `user_update` int(11) DEFAULT NULL,
  `date_created` timestamp NULL DEFAULT current_timestamp(),
  `date_update` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `persona_tipo_documento`
--

INSERT INTO `persona_tipo_documento` (`id`, `codigo`, `descripcion`, `user_create`, `user_update`, `date_created`, `date_update`) VALUES
(1, 'DNI', 'Documento Nacional', 1, NULL, '2026-02-27 14:34:40', '2026-02-27 14:34:40'),
(2, 'RUC', 'Registro Único de Contribuyente', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(3, 'PAS', 'Pasaporte', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(4, 'CE', 'Carnet de Extranjería', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(5, 'PTP', 'Permiso Temporal de Permanencia', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(6, 'DIE', 'Documento Identidad Extranjera', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(7, 'CIP', 'Cédula de Identidad Policial', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(8, 'CIM', 'Cédula de Identidad Militar', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(9, 'PEP', 'Permiso Especial de Permanencia', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(10, 'NIT', 'Número de Identificación Tributaria', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28'),
(11, 'LIC', 'Licencia de Conducir', 1, NULL, '2026-02-27 14:39:28', '2026-02-27 14:39:28');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_persona_tipo_documento` (`id_tipo_documento`);

--
-- Indices de la tabla `persona_correo`
--
ALTER TABLE `persona_correo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ix_persona_correo_id_persona` (`id_persona`);

--
-- Indices de la tabla `persona_direccion`
--
ALTER TABLE `persona_direccion`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ix_persona_direccion_id_persona` (`id_persona`);

--
-- Indices de la tabla `persona_empleo`
--
ALTER TABLE `persona_empleo`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ix_persona_empleo_id_persona` (`id_persona`);

--
-- Indices de la tabla `persona_tipo_documento`
--
ALTER TABLE `persona_tipo_documento`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `persona_correo`
--
ALTER TABLE `persona_correo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `persona_direccion`
--
ALTER TABLE `persona_direccion`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `persona_empleo`
--
ALTER TABLE `persona_empleo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `persona_tipo_documento`
--
ALTER TABLE `persona_tipo_documento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `persona`
--
ALTER TABLE `persona`
  ADD CONSTRAINT `fk_persona_tipo_documento` FOREIGN KEY (`id_tipo_documento`) REFERENCES `persona_tipo_documento` (`id`);

--
-- Filtros para la tabla `persona_correo`
--
ALTER TABLE `persona_correo`
  ADD CONSTRAINT `fk_persona_correo_persona` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `persona_direccion`
--
ALTER TABLE `persona_direccion`
  ADD CONSTRAINT `fk_persona_direccion_persona` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id`) ON DELETE CASCADE;

--
-- Filtros para la tabla `persona_empleo`
--
ALTER TABLE `persona_empleo`
  ADD CONSTRAINT `fk_persona_empleo_persona` FOREIGN KEY (`id_persona`) REFERENCES `persona` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
