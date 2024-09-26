# Ticket Alarm V1.1
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
Les tests unitaires se trouvent dans le projet "TicketAlarm.Application.UnitTests"
LEs tests d'intégration se trouvent dans le projet "TicketAlarm.API.IntegrationTests"

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

```sh
docker build -f API.Dockerfile . -t "nom"/apiticketalarm:prod
docker push "nom"/apiticketalarm:prod
```sh


Build et lancer le conteneur de production pour l'api et la base de données 
```sh
sudo docker compose -f docker-compose-vsl.yml build
sudo docker compose -f docker-compose-vsl.yml up -d
```sh

Lancer l'API avec le certificat 
```sh
sudo docker run  -it -p 81:81 -p 80:80  -e ASPNETCORE_URLS="https://*:81;http://*:80"  -v /etc/letsencrypt:/cert   -e ASPNETCORE_Kestrel__Certificates__Default__Path=/cert/live/vps.aaaab3nzac1yc.website/fullchain.pem   -e ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/cert/live/vps.aaaab3nzac1yc.website/privkey.pem   antoinemano/apiticketalarm:prod
```sh

Créer le certificat pour la production avec certbot 
```sh
 sudo certbot certonly --standalone -d vps.aaaab3nzac1yc.website --staple-ocsp -m antoine.mano@gmail.com --agree-tos
 ```sh

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


### VPS 

```sh
watch -n 5 free -m
```
