using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Persistence;

namespace TicketAlarm.API.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram>: WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(services =>
            {
                var dbContextDescriptior = services.ToList();
                var descriptor = services.SingleOrDefault( d => d.ServiceType == typeof(DbContextOptions<TicketAlarmDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }


                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection();
                    connection.Open();

                    return connection;
                });

                services.AddDbContext<TicketAlarmDbContext>((container, option) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    option.UseSqlite(connection);

                }, ServiceLifetime.Transient);

            });
        }
    }
}
