using Castle.Core.Smtp;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Models;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Mocks
{
    public static class MockEmailSender
    {
        public static Mock<Contracts.Infrastrucutre.IEmailSender> GetEmailSender()
        {
            var mockEmailSender = new Mock<Contracts.Infrastrucutre.IEmailSender>();

            mockEmailSender.Setup(r => r.SendEmail(It.IsAny<Email>())).Returns( (Email _) => Task.FromResult(true));

            return mockEmailSender;
        }
    }
}
