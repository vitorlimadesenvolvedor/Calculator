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

In project root folder, run the command below:
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

In both cases, the APIs will available in the addresses:

**API1**
```sh
http://localhost:5000
```
**API2**
```sh
http://localhost:5001
```

## Custom ports

### Docker

You can change ports in docker-compose.yml

```yml
version: '3.5'

services:
  api1:
    image: api1
    container_name: container_api1
    build:
      context: .
      dockerfile: API1/Dockerfile
    environment:
      - ASPNETCORE_URLS=http://localhost:[Custom port]:80   
    ports: 
      - "[Custom port]:80"  
  api2:
    image: api2
    container_name: container_api2
    build:
      context: .
      dockerfile: API2/Dockerfile
    environment:
      - ASPNETCORE_URLS=http://localhost:[Custom port]:443  
      - Services__API1=http://api1/
    ports: 
      - "[Custom port]:443"  
```

### .NET Core CLI

You can change ports in Properties/launchSettings.json

> Note: This process must be executed in the two projects: API 1 and API2

```json
"API1": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "http://localhost:[Custom port]"
    },
    
```
Also is necessary change the port in appsettings.json of the project API 2

```json
"Services": {
    "API1": "http://localhost:[Custom port]/"
  },
```

[ASP.NET Core]: <https://github.com/dotnet/aspnetcore>
[Docker]: <https://github.com/docker>
[Swagger]: <https://github.com/swagger-api/swagger-ui>
