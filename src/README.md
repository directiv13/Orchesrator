# SQL SERVER
```powershell
docker pull mcr.microsoft.com/mssql/server:2022-latest
```
```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" `
   -p 1433:1433 --name sql1 --hostname sql1 `
   -d `
   mcr.microsoft.com/mssql/server:2022-latest
```
## Connection string
```json
"ConnectionStrings": {
    "Workflow": "Server=localhost,1433;Initial Catalog=orchestrator;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultSets=true;"
}
```
# MongoDB
```powershell
docker pull mongo:latest
```
```powershell
docker run -d -p 2717:27017 -v ./mongodb:/data/db --name test-mongodb mongo:latest
```