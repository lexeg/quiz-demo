CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240330175624_InitialCreate') THEN
    CREATE TABLE tests_table (
        id uuid NOT NULL,
        name character varying(150) NOT NULL,
        description character varying(1000) NOT NULL,
        CONSTRAINT "TestsTable_pkey" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240330175624_InitialCreate') THEN
    CREATE TABLE questions_table (
        id uuid NOT NULL,
        test_id uuid NOT NULL,
        question character varying(500) NOT NULL,
        answers json NOT NULL,
        CONSTRAINT questions_table_pkey PRIMARY KEY (id),
        CONSTRAINT questions_table_test_id_fkey FOREIGN KEY (test_id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240330175624_InitialCreate') THEN
    CREATE TABLE test_results_table (
        id uuid NOT NULL,
        test_id uuid NOT NULL,
        email character varying(100) NOT NULL,
        answers json NOT NULL,
        CONSTRAINT test_results_table_pkey PRIMARY KEY (id),
        CONSTRAINT test_results_table_id_fkey FOREIGN KEY (id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240330175624_InitialCreate') THEN
    CREATE INDEX "IX_questions_table_test_id" ON questions_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240330175624_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240330175624_InitialCreate', '8.0.3');
    END IF;
END $EF$;
COMMIT;

