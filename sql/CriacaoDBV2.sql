CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `cliente` (
    `CLIENTE_ID` int NOT NULL AUTO_INCREMENT,
    `RAZAO_SOCIAL` longtext CHARACTER SET utf8mb4 NULL,
    `DATA_FUNDACAO` datetime(6) NOT NULL,
    `CNPJ` longtext CHARACTER SET utf8mb4 NULL,
    `CAPITAL` decimal(65,30) NOT NULL,
    `QUARENTENA` tinyint(1) NOT NULL,
    `STATUS_CLIENTE` tinyint(1) NOT NULL,
    `CLASSIFICACAO` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_cliente` PRIMARY KEY (`CLIENTE_ID`)
) CHARACTER SET utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210811032834_start', '5.0.9');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210811233511_V2', '5.0.9');

COMMIT;

