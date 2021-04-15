
### Projeto: 

** Configurações da arquitetura back-end com .NET Core **

Site: [Digital Innovation One](http://www.digitalinnovation.one/)


dotnet add WebApi.csproj package Swashbuckle.AspNetCore
dotnet add WebApi.csproj package Swashbuckle.AspNetCore.Annotations
dotnet add WebApi.csproj package Microsoft.AspNetCore.Authentication
dotnet add WebApi.csproj package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add WebApi.csproj package Microsoft.EntityFrameworkCore
dotnet add WebApi.csproj package Microsoft.EntityFrameworkCore.Relational
dotnet add WebApi.csproj package Microsoft.EntityFrameworkCore.SqlServer
dotnet add WebApi.csproj package Microsoft.EntityFrameworkCore.Tools

dotnet tool update --global dotnet-ef 

dotnet ef migrations add Inicio

