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
    public class AlarmConfiguration : IEntityTypeConfiguration<Alarm>
    {
        public void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.HasData(new Alarm()
            {
                Id = 1,
                IdShow = 1,
                Mail = "test@gmail.com",
                Phone = "+33622334455",
            });

            builder.HasKey(a => a.Id);
        }
    }
}
