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
    public static class MockTokenGenerator
    {
        public static Mock<ITokenGenerator> GetTokenGenerator()
        {
            var mockTokenGenerator = new Mock<ITokenGenerator>();

            mockTokenGenerator.Setup(m => m.GenerateToken(It.IsAny<string>(), It.IsAny<string>() )).Returns("token");

            return mockTokenGenerator;
        }
    }
}
