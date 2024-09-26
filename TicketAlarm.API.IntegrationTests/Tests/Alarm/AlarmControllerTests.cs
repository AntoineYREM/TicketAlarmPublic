using FluentAssertions;
using System.Net.Http.Json;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Artist;

namespace TicketAlarm.API.IntegrationTests.Tests.Alarm
{
    public class AlarmControllerTests : BaseTest
    {
        private CustomWebApplicationFactory<Program> _factory;
        private HttpClient _httpClient;

        public AlarmControllerTests(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

            _httpClient = factory.CreateClient(new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions());
        }

        [Fact]
        public async Task GetArtist_ArtistExist_ReturnSuccessWithArtits()
        {
            var response = await _httpClient.GetAsync("api/alarms/1");
            var result = await response.Content.ReadFromJsonAsync<List<AlarmDto>>();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            result.Should().HaveCount(1);
        }
    }
}
