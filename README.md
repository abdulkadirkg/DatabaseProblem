# DatabaseProblem
## Docker Database Command;

```
docker run -d --name PG -e POSTGRES_USER=test -e POSTGRES_DB=testdb -e POSTGRES_PASSWORD=test -e PGDATA=/var/lib/postgresql/data/pgdata -p 5432:5432 postgres
```

# Create Table Script
```
-- public."DummyDataClasses" definition

-- Drop table

-- DROP TABLE public."DummyDataClasses";

CREATE TABLE public."DummyDataClasses" (
	"Id" uuid NOT NULL,
	"Field1" text NOT NULL,
	"Field2" text NOT NULL,
	"Field3" text NOT NULL,
	"FieldInt" int4 NOT NULL,
	"FieldBool" bool NOT NULL,
	"SearchVector" tsvector NULL GENERATED ALWAYS AS (to_tsvector('turkish'::regconfig, ((("Field1" || ' '::text) || "Field2") || ' '::text) || "Field3")) STORED,
	CONSTRAINT "PK_DummyDataClasses" PRIMARY KEY ("Id")
);
CREATE INDEX "IX_DummyDataClasses_SearchVector" ON public."DummyDataClasses" USING gin ("SearchVector");
```
## Please don't forget apply the migration. You can apply it like that;
```dotnet ef database update```
