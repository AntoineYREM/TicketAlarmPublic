# Ticket Alarm V0.1
![](https://github.com/AntoineYREM/TicketAlarm/blob/master/demo-v0.gif)




### Géneration du client 

Utilisation du projet suivant pour la création du code client javascript et C#

[openapi-generator](https://nodejs.org/)https://github.com/OpenAPITools/openapi-generator 

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

