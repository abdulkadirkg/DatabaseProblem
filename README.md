# DatabaseProblem
## Docker Database Command;

```
docker run -d --name PG -e POSTGRES_USER=test -e POSTGRES_DB=testdb -e POSTGRES_PASSWORD=test -e PGDATA=/var/lib/postgresql/data/pgdata -p 5432:5432 postgres
```

## Please don't forget apply the migration. You can apply it like that;
```dotnet ef database update```
