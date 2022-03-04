CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Movies" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Movies" PRIMARY KEY AUTOINCREMENT,
    "Title" TEXT NOT NULL
);

INSERT INTO "Movies" ("Id", "Title")
VALUES (1, 'Some Cartoon');

INSERT INTO "Movies" ("Id", "Title")
VALUES (2, 'A Documentary');

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220304195335_SeedMovies', '6.0.2');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Movies" ADD "Rating" TEXT NOT NULL DEFAULT '';

UPDATE "Movies" SET "Rating" = 'Good'
WHERE "Id" = 1;
SELECT changes();


INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220304195711_AddRatingToSeedData', '6.0.2');

COMMIT;