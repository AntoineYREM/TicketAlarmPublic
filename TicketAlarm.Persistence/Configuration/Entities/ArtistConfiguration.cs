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
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(new Artist()
            {
                Id = 1,
                Name = "Billie Eilish",
                UrlPhoto = "https://www.fnacspectacles.com/obj/mam/france/9c/4a/billi-eilish-tickets_152737_1374605_222x222.jpg"
            });

            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Shows).WithOne(a => a.Artist).HasForeignKey(s => s.IdArtist).IsRequired();



        }
    }
}
