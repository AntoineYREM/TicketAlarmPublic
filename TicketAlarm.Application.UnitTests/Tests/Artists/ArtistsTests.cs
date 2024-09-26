using AutoMapper;
using Moq;
using Shouldly;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Artist.Handlers.Commands;
using TicketAlarm.Application.Features.Artist.Requests.Commands;
using TicketAlarm.Application.Profile;
using TicketAlarm.Application.UnitTests.Mocks;

namespace TicketArtist.Application.UnitTests.Tests.Artists
{
    public class AvailabilitysTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public AvailabilitysTests()
        {
            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task Create_Artist_ReturnsCorrectResults()
        {
            var handler = new CreateArtistRequestHandler(_mockUnitOfWork.Object, _mapper);
            var result = await handler.Handle(new CreateArtistRequest
            {
                ArtistDto = new()
                {
                    Name = "Test",
                    UrlPhoto = "http://photo.com/artist"
                }
            }, CancellationToken.None);


            var artists = await _mockUnitOfWork.Object.ArtistRepository.GetAllAsync();

            artists.Count().ShouldBe(2);
        }
    }
}
