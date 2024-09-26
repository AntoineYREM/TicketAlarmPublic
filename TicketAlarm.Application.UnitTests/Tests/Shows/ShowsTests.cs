using AutoMapper;
using FluentValidation;
using Moq;
using Shouldly;
using System;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Show.Handlers.Commands;
using TicketAlarm.Application.Features.Show.Handlers.Queries;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Tests.Shows
{

    public class ShowsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWorkmock;

        public ShowsTests()
        {
            _unitOfWorkmock = MockUnitOfWork.GetUnitOfWork();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Create_Show_ReturnsError()
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

        [Fact]
        public async Task Create_Show_ReturnsCorrectResults()
        {
            var handler = new CreateShowRequestHandler(_unitOfWorkmock.Object, _mapper);
            var result = await handler.Handle(new CreateShowRequest()
            {
                ShowDto = new ShowDto()
                {
                    IdArtist = 1,
                    Arena = "Accor Arena",
                    Available = false,
                    City = "Paris",
                    DateTimeShow = new DateTime(638851788000000000),
                    IdFnac = 18631108,
                    Title = "Show",
                    Url = "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/"
                }
            }, CancellationToken.None);


            var shows = await _unitOfWorkmock.Object.ShowRepository.GetAllAsync();

            shows.Count().ShouldBe(3);
            result.ShouldBeOfType<int>();
        }

        [Fact]
        public async Task Update_Show_ReturnsCorrectResults()
        {
            var handler = new UpdateShowRequestHandler(_unitOfWorkmock.Object, _mapper);
            var result = await handler.Handle(new UpdateShowRequest()
            {
                Id = 1,
                ShowDto = new ShowDto()
                {
                    IdArtist = 1,
                    Arena = "Accor Arena",
                    Available = true,
                    City = "Paris",
                    DateTimeShow = new DateTime(638891788000000000),
                    IdFnac = 18631108,
                    Title = "Show",
                    Url = "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/"
                }
            }, CancellationToken.None);


            var show = await _unitOfWorkmock.Object.ShowRepository.GetSingleAsync(s => s.Id == 1);

            show.Available.ShouldBe(true);
            show.DateTimeShow.ShouldBe(new DateTime(638891788000000000));
        }

        [Fact]
        public async Task Get_Show_ReturnsCorrectResults()
        {
            var handler = new GetShowRequestHandler(_unitOfWorkmock.Object, _mapper);
            var result = await handler.Handle(new GetShowRequest()
            {
                Id = 1,
            }, CancellationToken.None);


            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Get_Shows_ReturnsCorrectResults()
        {
            var handler = new GetShowsRequestHandler(_unitOfWorkmock.Object, _mapper);
            var result = await handler.Handle(new GetShowsRequest()
            {
                Active = false,
            }, CancellationToken.None);


            result.Count().ShouldBe(2);
        }
    }
}
