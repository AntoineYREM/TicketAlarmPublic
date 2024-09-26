using AutoMapper;
using FluentValidation;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Alarm.Handlers.Commands;
using TicketAlarm.Application.Features.Show.Handlers.Commands;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Shows.Command
{
    public class CreateShowRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWorkmock;

        public CreateShowRequestHandlerTests()
        {
            _unitOfWorkmock = MockUnitOfWork.GetUnitOfWork();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task CreateWrongShowRequest()
        {
            var handler = new CreateShowRequestHandler(_unitOfWorkmock.Object, _mapper);

            ValidationException ex = await Should.ThrowAsync<ValidationException>(async () =>
            {
                await handler.Handle(new CreateShowRequest()
                {
                    ShowDto = new ShowDto()
                    {
                        IdArtist = 1,
                        Arena = "Accor Arena",
                        Available = false,
                        City = "Paris",
                        DateTimeShow = new DateTime(638851788000000000),
                        IdFnac = 18631108,
                        Title = null,
                        Url = "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/"
                    }
                }, CancellationToken.None);
            });
        }
    }
}
