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

namespace TicketAlarm.Application.UnitTests.Tests.Alarms
{
    public class AlarmsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public AlarmsTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Get_Alarms_ReturnsCorrectResults()
        {
            var handler = new GetAlarmsRequestHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetAlarmsRequest() { IdShow = 1 }, CancellationToken.None);

            result.ShouldBeOfType<List<AlarmDto>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Create_Alarm_ReturnsCorrectResults()
        {
            var handler = new CreateAlarmRequestHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new Features.Alarm.Requests.Commands.CreateShowRequest()
            {
                AlarmDto = new AlarmDto()
                {
                    IdShow = 1,
                    Mail = "test2@gmail.com",
                    Phone = "+33622334466",
                }
            }, CancellationToken.None);


            var alarms = await _mockUnitOfWork.Object.AlarmRepository.GetAllAsync();

            alarms.Count().ShouldBe(2);
            result.Return.ShouldBeOfType<int>();
        }

        [Fact]
        public async Task Update_Alarm_ReturnsCorrectResults()
        {
            var handler = new UpdateAlarmRequestHandler(_mockUnitOfWork.Object, _mapper);
            var updatedAlarm = new AlarmDto()
            {
                IdAlarm = 1,
                IdShow = 1,
                Mail = "test-updated@gmail.com",
                Phone = "+33622334499",
            };

            var result = await handler.Handle(new Features.Alarm.Requests.Commands.UpdateAlarmRequest()
            {
                Id = 1,
                AlarmDto = updatedAlarm
            }, CancellationToken.None);


            var alarm = await _mockUnitOfWork.Object.AlarmRepository.GetSingleAsync(a => a.Id == 1);

            _mapper.Map<AlarmDto>(alarm).Mail.ShouldBeEquivalentTo(updatedAlarm.Mail);
        }
    }
}
