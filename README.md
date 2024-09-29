# Ticket Alarm V0.2
![](https://github.com/AntoineYREM/TicketAlarm/blob/master/demo-v0.gif)




### Géneration du client 

Utilisation du projet suivant pour la création du code client javascript et C#

[openapi-generator](https://github.com/OpenAPITools/openapi-generator)

Commandes pour générer le code client

Javascript
```sh
java -jar modules/swagger-codegen-cli/target/swagger-codegen-cli.jar generate -i https://petstore.swagger.io/v2/swagger.json  -l javascript  -o C:\Users\Antoine\Documents\TicketAlarm\TicketAlarm.UI.React\ticket-alarm-ui-react\src\client
```

C#
```sh
java -jar modules/openapi-generator-cli/target/openapi-generator-cli.jar generate -i swagger.json  -g javascript   -o C:\Users\Antoine\Documents\TicketAlarm\TicketAlarm.UI.React\ticketalarm\src\client
```

### Test 
Les tests unitaires se trouvent dans le projet 
TicketAlarm.Application.UnitTests

### Docker 
```sh
docker-compose up 
```

### Base de données
```sh
add-migration "nom migration" 
update-database
```

### Docker


```sh
docker build -f API.Dockerfile .
```

```sh
docker run -d -p 4444:4444 -p 7900:7900 -e SE_NODE_MAX_SESSIONS=5  --shm-size="2g" selenium/standalone-chrome:latest
```