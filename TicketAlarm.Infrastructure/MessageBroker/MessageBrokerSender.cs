using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Models;

namespace TicketAlarm.Infrastructure.MessageBroker
{
    public class MessageBrokerSender : IMessageBrokerSender
    {
        public MessageBrokerSettings MessageBrokerSettings { get; }

        public MessageBrokerSender(IOptions<MessageBrokerSettings> messageBrokerSettings)
        {
            MessageBrokerSettings = messageBrokerSettings.Value;
        }

        public Task<bool> QueueMessage(object message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = MessageBrokerSettings.Url,
                UserName = "admin",
                Password = "mypass",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare("email", true, false, false);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "email", body: body);

            return Task.FromResult(true);
        }
    }
}
