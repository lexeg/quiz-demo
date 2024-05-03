CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE TABLE branch_office_table (
        id uuid NOT NULL,
        name character varying(200) NOT NULL,
        prefix character varying(10) NOT NULL,
        CONSTRAINT branch_office_table_pkey PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE TABLE educational_program_table (
        external_id uuid NOT NULL,
        name character varying(100) NOT NULL,
        CONSTRAINT educational_program_table_pkey PRIMARY KEY (external_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
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
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE TABLE test_results_table (
        id uuid NOT NULL,
        test_id uuid NOT NULL,
        branch_office_id uuid NOT NULL,
        educational_program_id uuid NOT NULL,
        email character varying(100) NOT NULL,
        full_name character varying(100) NOT NULL,
        mobile_phone character varying(20) NOT NULL,
        presigned_url character varying(300) NOT NULL,
        expired_date timestamp with time zone NOT NULL,
        answers json NOT NULL,
        CONSTRAINT test_results_table_pkey PRIMARY KEY (id),
        CONSTRAINT test_results_table_branch_office_id_fkey FOREIGN KEY (branch_office_id) REFERENCES branch_office_table (id),
        CONSTRAINT test_results_table_educational_program_id_fkey FOREIGN KEY (educational_program_id) REFERENCES educational_program_table (external_id),
        CONSTRAINT test_results_table_id_fkey FOREIGN KEY (test_id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE INDEX "IX_questions_table_test_id" ON questions_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE INDEX "IX_test_results_table_branch_office_id" ON test_results_table (branch_office_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE INDEX "IX_test_results_table_educational_program_id" ON test_results_table (educational_program_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_test_results_table_test_id" ON test_results_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240503151741_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240503151741_InitialCreate', '8.0.3');
    END IF;
END $EF$;
COMMIT;

