using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Persistence;

namespace TicketAlarm.API.IntegrationTests.Tests
{
    public class BaseTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        public BaseTest(CustomWebApplicationFactory<Program> factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TicketAlarmDbContext>();
                db.Database.EnsureCreated();
                //db.Database.Migrate();
                Seeding.InitilizeTestDb(db);
            }
        }
    }
}
