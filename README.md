# Calculator

Calculator is an API that provides some financial calculator services.

The project consists in two APIs:
- API1 is responsible for provides the interest rate. 
- API2 provides financial calculator services using the interest rate of API1

_Both projects have a **[Swagger]** interface_
## Tech

Calculator was built with that technologies:

- [ASP.NET Core] 
- [Docker] 

## Quick Start with Docker

> Note: If you are a Windows user, make sure that Docker is running in Linux containers mode.

In root folder, run the command below:
```sh
docker-compose up -d
```
## Or with .NET Core CLI

Enter in API1 folder and execute the command below:
```sh
dotnet run
```
Repeat the process in API2 folder:
```sh
dotnet run
```

## License

MIT

[ASP.NET Core]: <https://github.com/dotnet/aspnetcore>
[Docker]: <https://github.com/docker>
[Swagger]: <https://github.com/swagger-api/swagger-ui>
