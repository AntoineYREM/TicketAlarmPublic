using AutoMapper;
using Moq;
using Shouldly;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.Features.Alarm.Handlers.Commands;
using TicketAlarm.Application.Features.Alarm.Handlers.Queries;
using TicketAlarm.Application.Features.Alarm.Requests.Queries;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Alarms.Queries
{
    public class GetAlarmsRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAlarmRepository> _alarmRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetAlarmsRequestHandlerTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task GetAlarmsRequest()
        {
            var handler = new GetAlarmsRequestHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetAlarmsRequest() { IdShow = 1 }, CancellationToken.None);

            result.ShouldBeOfType<List<AlarmDto>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAlarmRequest()
        {
            var handler = new CreateAlarmRequestHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new Features.Alarm.Requests.Commands.CreateShowRequest() { AlarmDto = new AlarmDto()
            {
                IdShow = 1,
                Mail = "test2@gmail.com",
                Phone = "+33622334466",
            }
            }, CancellationToken.None);


            var alarms = await _alarmRepository.Object.GetAllAsync();

            alarms.Count().ShouldBe(2);
            result.Return.ShouldBeOfType<int>();
        }
    }
}
