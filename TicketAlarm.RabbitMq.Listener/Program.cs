
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
using Newtonsoft.Json;
using Org.OpenAPITools.Model;

Console.WriteLine("--- RabbitMq ---");
var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var urlApi = (environmentName != null) ? "http://api:80/" : "https://localhost:7015/";
var urlRabbitMq = (environmentName != null) ? "mqrabbit" : "localhost";

Configuration c = new Configuration();
c.BasePath = urlApi;
var emailApi = new EmailApi(c);


var factory = new ConnectionFactory()
{
    HostName = urlRabbitMq,
    UserName = "admin",
    Password = "mypass",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("email", true, false, false);
var consumer = new EventingBasicConsumer(channel);
consumer.Received += Consumer_Received;

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"A message has been reveived ? - {message}");
    try
    {

        var alarmDto = JsonConvert.DeserializeObject<AlarmDto>(message);
        var idEmail = emailApi.ApiEmailPost(alarmDto);
        channel.BasicAck(e.DeliveryTag, false);
    }catch(Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
 
}

channel.BasicConsume("email", false, consumer);
Console.ReadLine();
Console.WriteLine("End");