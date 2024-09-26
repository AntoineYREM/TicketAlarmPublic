using AutoMapper;
using Castle.Core.Smtp;
using Moq;
using Shouldly;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Artist.Handlers.Commands;
using TicketAlarm.Application.Features.Artist.Requests.Commands;
using TicketAlarm.Application.Features.Availability.Handlers.Commands;
using TicketAlarm.Application.Features.Availability.Requests.Commands;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;

namespace TicketArtist.Application.UnitTests.Tests.Availabilitys
{
    public class AvailabilitysTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<TicketAlarm.Application.Contracts.Infrastrucutre.IEmailSender> _mockEmailSender;
        private readonly Mock<IMessageBrokerSender> _mockMessageBrokerSender;
        private readonly Mock<ITokenGenerator> _mockTokenGenerator;

        public AvailabilitysTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mockMessageBrokerSender = MockMessageBrokerSender.GetMessageBrocker();
            _mockTokenGenerator = MockTokenGenerator.GetTokenGenerator();
            _mockEmailSender = MockEmailSender.GetEmailSender();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Create_Availability_ReturnsCorrectResults()
        {
            var handler = new CreateAvailabilityRequestHandler(_mockUnitOfWork.Object, _mapper, _mockEmailSender.Object, _mockMessageBrokerSender.Object, _mockTokenGenerator.Object);
            var result = await handler.Handle(new CreateAvailabilityRequest
            {
                AvailabilityDto = new()
                {
                    IdShow = 1,
                    Screenshot = "http://google.fr/screen"
                }
            }, CancellationToken.None);


            var availabilitys = await _mockUnitOfWork.Object.AvailabilityRepository.GetAllAsync();

            availabilitys.Count().ShouldBe(2);
        }
    }
}
