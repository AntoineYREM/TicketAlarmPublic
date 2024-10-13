using FluentAssertions;
using System.Net.Http.Json;
using TicketAlarm.Application.DTOs.Artist;

namespace TicketAlarm.API.IntegrationTests.Tests.Artist
{
    public class ArtistControllerTests : BaseTest
    {
        private CustomWebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        public ArtistControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            
            _httpClient = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true
            });
        }

        [Fact]
        public async Task GetArtist_ArtistExist_ReturnSuccessWithArtits()
        {
            var response = await _httpClient.GetAsync("api/artists");
            var result = await response.Content.ReadFromJsonAsync<List<ArtistDto>>();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Should().HaveCount(2);
        }
    }
}
