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
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.HasData(new Show()
            {
                Id = 1,
                IdArtist = 1,
                Arena = "Accor Arena",
                Available = false,
                City = "Paris",
                DateTimeShow = new DateTime(638851788000000000),
                IdFnac = 18631108,
                Title = "Billie Eilish - Hit Me Hard and Soft Tour",
                Url = "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/"
            });

            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Artist)
                .WithMany(a => a.Shows)
                .HasForeignKey(s => s.IdArtist);

            builder.HasMany(s => s.Alarms).WithOne(a => a.Show).HasForeignKey(a => a.IdShow);


        }
    }
}
