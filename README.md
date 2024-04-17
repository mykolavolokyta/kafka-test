# CyberArena
## Getting started
### Instalation
1. Make sure that you have all tools needed to build project installed and added to the PATH:
    - Kafka server started on port 9092
    - .NET 8 or higher
2. Clone the repository `git clone https://github.com/mykolavolokyta/kafka-test.git`
## Instalation
To build project:
```
dotnet build
```
## Running
- Tournament Management Service

	To run service:
```
cd TournamentManagementService
dotnet run
```
Service is located in ```\bin\Debug\net8.0\TournamentManagementService.exe```
- Communication Service

	To run service:
```
cd CommunicationService
dotnet run
```
Service is located in ```\bin\Debug\net8.0\CommunicationService.exe```