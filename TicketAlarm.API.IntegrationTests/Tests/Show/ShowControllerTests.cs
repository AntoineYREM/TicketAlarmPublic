using FluentAssertions;
using System.Net.Http.Json;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Show;

namespace TicketAlarm.API.IntegrationTests.Tests.Show
{
    public class ShowControllerTests : BaseTest
    {
        private HttpClient _httpClient;

        public ShowControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            _httpClient = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task GetShows_ShowsExist_ReturnSuccessWithShows()
        {
            var response = await _httpClient.GetAsync("api/shows");
            var result = await response.Content.ReadFromJsonAsync<List<ShowDto>>();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Should().HaveCount(1);
        }
    }
}
