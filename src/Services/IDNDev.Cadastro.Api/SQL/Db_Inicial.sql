CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'Cadastros') THEN
        CREATE SCHEMA "Cadastros";
    END IF;
END $EF$;

CREATE TABLE "Cadastros"."Pessoas" (
    "Id" uuid NOT NULL,
    "Nome" varchar(60) NOT NULL,
    "Documento" varchar(14) NOT NULL,
    "Idade" integer NOT NULL,
    CONSTRAINT "PK_Pessoas" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20260201142934_Db_Inicial', '10.0.2');

COMMIT;

