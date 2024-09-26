using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Mocks
{
    public static class MockMessageBrokerSender
    {
        public static Mock<IMessageBrokerSender> GetMessageBrocker()
        {
            var mockMessageBrocker = new Mock<IMessageBrokerSender>();

            mockMessageBrocker.Setup(m => m.QueueMessage(It.IsAny<object>())).Returns(() => Task.FromResult(true));

            return mockMessageBrocker;
        }
    }
}
