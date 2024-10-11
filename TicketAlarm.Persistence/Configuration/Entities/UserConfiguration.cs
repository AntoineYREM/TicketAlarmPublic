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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User()
            {
                Id = 1,
                EmailAddress = "test@ticketalarm.com",
                Password = "yourStrong(!)Password",
                Role = "admin"
            });

            builder.HasKey(s => s.Id);
        }
    }
}
