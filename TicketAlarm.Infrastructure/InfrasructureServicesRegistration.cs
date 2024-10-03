using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Models;
using TicketAlarm.Infrastructure.Mail;
using TicketAlarm.Infrastructure.MessageBroker;

namespace TicketAlarm.Infrastructure
{
    public static class InfrasructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrasructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<MessageBrokerSettings>(configuration.GetSection("MessageBrokerSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IMessageBrokerSender, MessageBrokerSender>();
            return services;
        }
    }
}
