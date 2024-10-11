# Ticket Alarm V0.3
![](https://github.com/AntoineYREM/TicketAlarm/blob/master/demo-v0.gif)




### Géneration du client 

Utilisation du projet suivant pour la création du code client javascript et C#

[openapi-generator](https://github.com/OpenAPITools/openapi-generator)

Commandes pour générer le code client

Javascript
```sh
java -jar modules/openapi-generator-cli/target/openapi-generator-cli.jar generate -i swagger.json   -g javascript  -o C:\Users\Antoine\Documents\TicketAlarm\TicketAlarm.UI.React\ticket-alarm-ui-react\src\client
```

C#
```sh
java -jar modules/openapi-generator-cli/target/openapi-generator-cli.jar generate -i swagger.json  -g csharp   -o C:\Users\Antoine\Documents\TicketAlarm\ClientCsharp\
```

### RabbitMq

Admin
http://localhost:15672/

### Test 
Les tests unitaires se trouvent dans le projet 
TicketAlarm.Application.UnitTests

### Docker 
```sh
docker-compose up 
```

```sh
docker build -f API.Dockerfile .
```

```sh
docker run -d -p 4444:4444 -p 7900:7900 -e SE_NODE_MAX_SESSIONS=5  --shm-size="2g" selenium/standalone-chrome:latest
```


### Base de données
```sh
add-migration "nom migration" 
update-database
```


### SonarQube



```sh
dotnet sonarscanner begin /k:"TicketAlarm" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_2be6fcb39963a327a752fa7c23d5d883b649d954" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml /d:sonar.scanner.scanAll=false
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end /d:sonar.token="sqp_2be6fcb39963a327a752fa7c23d5d883b649d954"
```


### Notes

```sh
DELETE FROM Availabilitys
DELETE FROM Shows
DELETE FROM Artists
DELETE FROM Alarms
```