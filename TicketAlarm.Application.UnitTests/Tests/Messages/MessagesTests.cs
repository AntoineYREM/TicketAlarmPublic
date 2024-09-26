using AutoMapper;
using Castle.Core.Smtp;
using Moq;
using Shouldly;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Availability.Handlers.Commands;
using TicketAlarm.Application.Features.Availability.Requests.Commands;
using TicketAlarm.Application.Features.Message.Handlers.Commands;
using TicketAlarm.Application.Features.Message.Requests.Commands;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;

namespace TicketArtist.Application.UnitTests.Tests.MessagesTests
{
    public class MessagesTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<TicketAlarm.Application.Contracts.Infrastrucutre.IEmailSender> _mockEmailSender;
        private readonly Mock<IMessageBrokerSender> _mockMessageBrokerSender;
        private readonly Mock<ITokenGenerator> _mockTokenGenerator;


        public MessagesTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mockMessageBrokerSender = MockMessageBrokerSender.GetMessageBrocker();
            _mockEmailSender = MockEmailSender.GetEmailSender();
            _mockTokenGenerator = MockTokenGenerator.GetTokenGenerator();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Create_Message_ReturnsCorrectResults()
        {
            var handler = new SendEmailRequestHandler(_mockUnitOfWork.Object, _mapper, _mockEmailSender.Object, _mockMessageBrokerSender.Object, _mockTokenGenerator.Object);
            var result = await handler.Handle(new SendEmailRequest
            {
                AlarmInformation = new()
                {
                    IdShow = 1,
                    IdAlarm = 1,
                    Mail = "test@gmail.com",
                }
            }, CancellationToken.None);


            var availability = await _mockUnitOfWork.Object.AlarmRepository.GetSingleAsync(a => a.Id == 1);

            availability.DateTimeMailSent.ShouldNotBeNull();
        }
    }
}
