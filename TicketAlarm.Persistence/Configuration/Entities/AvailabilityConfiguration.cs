using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;

namespace TicketAlarm.Persistence.Configuration.Entities
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.HasData(new Availability()
            {
                Id = 1,
                IdShow = 1,
                DateTimeAvailability = DateTime.Now
            });

            builder.HasKey(a => a.Id);
        }
    }
}
