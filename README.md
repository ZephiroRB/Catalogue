### Console

```
dotnet run -p Catalogue.Api/
```

### Scaffold

```
Scaffold-DbContext "Server=127.0.0.1;port=5432;user id=postgres;password=<password-here>;database=Catalogue;pooling=true" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Data -force
```

