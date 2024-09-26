ECHO ============================
java -jar Toolbox/openapi-generator-cli/target/openapi-generator-cli.jar generate -i Toolbox/openapi-generator-cli/swagger.json   -g javascript  -o TicketAlarm.UI.React\ticket-alarm-ui-react\src\client
java -jar Toolbox/openapi-generator-cli/target/openapi-generator-cli.jar generate -i Toolbox/openapi-generator-cli/swagger.json  -g csharp   -o ClientCsharp\
java -jar Toolbox/openapi-generator-cli/target/openapi-generator-cli.jar generate -i Toolbox/openapi-generator-cli/swagger.json   -g  typescript-angular  -o TicketAlarm.UI.Angular\TicketAlarmUI\src\client
PAUSE


