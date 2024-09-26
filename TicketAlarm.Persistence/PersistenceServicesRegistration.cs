using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Persistence.Repositories;

namespace TicketAlarm.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketAlarmDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("TicketAlarmConnectionString"));
                
            }, ServiceLifetime.Transient);


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
