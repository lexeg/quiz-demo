CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE branch_office_table (
        id uuid NOT NULL,
        name character varying(200) NOT NULL,
        prefix character varying(10) NOT NULL,
        CONSTRAINT "PK_branch_office_table" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE educational_program_table (
        external_id uuid NOT NULL,
        name character varying(100) NOT NULL,
        CONSTRAINT "PK_educational_program_table" PRIMARY KEY (external_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE tests_table (
        id uuid NOT NULL,
        name character varying(150) NOT NULL,
        description character varying(1000) NOT NULL,
        CONSTRAINT "PK_tests_table" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE presigned_url_table (
        id uuid NOT NULL,
        branch_office_id uuid NOT NULL,
        educational_program_id uuid NOT NULL,
        test_id uuid NOT NULL,
        presigned_url character varying(300) NOT NULL,
        expired_date timestamp with time zone NOT NULL,
        CONSTRAINT "PK_presigned_url_table" PRIMARY KEY (id),
        CONSTRAINT "FK_presigned_url_table_branch_office_table_branch_office_id" FOREIGN KEY (branch_office_id) REFERENCES branch_office_table (id),
        CONSTRAINT "FK_presigned_url_table_educational_program_table_educational_p~" FOREIGN KEY (educational_program_id) REFERENCES educational_program_table (external_id),
        CONSTRAINT "FK_presigned_url_table_tests_table_test_id" FOREIGN KEY (test_id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE questions_table (
        id uuid NOT NULL,
        test_id uuid NOT NULL,
        question character varying(500) NOT NULL,
        answers json NOT NULL,
        CONSTRAINT "PK_questions_table" PRIMARY KEY (id),
        CONSTRAINT "FK_questions_table_tests_table_test_id" FOREIGN KEY (test_id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE TABLE test_results_table (
        id uuid NOT NULL,
        test_id uuid NOT NULL,
        branch_office_id uuid NOT NULL,
        educational_program_id uuid NOT NULL,
        email character varying(100) NOT NULL,
        full_name character varying(100) NOT NULL,
        mobile_phone character varying(20) NOT NULL,
        answers json NOT NULL,
        CONSTRAINT "PK_test_results_table" PRIMARY KEY (id),
        CONSTRAINT "FK_test_results_table_branch_office_table_branch_office_id" FOREIGN KEY (branch_office_id) REFERENCES branch_office_table (id),
        CONSTRAINT "FK_test_results_table_educational_program_table_educational_pr~" FOREIGN KEY (educational_program_id) REFERENCES educational_program_table (external_id),
        CONSTRAINT "FK_test_results_table_tests_table_test_id" FOREIGN KEY (test_id) REFERENCES tests_table (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_presigned_url_table_branch_office_id" ON presigned_url_table (branch_office_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_presigned_url_table_educational_program_id" ON presigned_url_table (educational_program_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_presigned_url_table_expired_date_presigned_url" ON presigned_url_table (expired_date, presigned_url);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_presigned_url_table_test_id" ON presigned_url_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_questions_table_test_id" ON questions_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_test_results_table_branch_office_id" ON test_results_table (branch_office_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE INDEX "IX_test_results_table_educational_program_id" ON test_results_table (educational_program_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_test_results_table_test_id" ON test_results_table (test_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240506110916_InitialCreate') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240506110916_InitialCreate', '8.0.3');
    END IF;
END $EF$;
COMMIT;

