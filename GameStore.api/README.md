## starting sql server

```powershell
$sa_password="[SA PASS HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## setting the connection string to secret manager

```powershell

$sa_password="[SA PASS HERE]"

dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost;Database=GameStore;User Id=sa;Password=$sa_password; TrustServerCertificate=True;"

```
