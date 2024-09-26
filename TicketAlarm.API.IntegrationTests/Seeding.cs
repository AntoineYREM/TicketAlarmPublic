using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;
using TicketAlarm.Persistence;

namespace TicketAlarm.API.IntegrationTests
{
    public class Seeding
    {
        public static void InitilizeTestDb(TicketAlarmDbContext db)
        {
            db.Artists.AddRange(GetArtists());
            db.SaveChanges();
        }

        private static List<Artist> GetArtists()
        {
            return new List<Artist>
            {
                new Artist()
                {
                    Id = 2,
                    Name = "Billie Eilish",
                    UrlPhoto = "https://www.fnacspectacles.com/obj/mam/france/9c/4a/billi-eilish-tickets_152737_1374605_222x222.jpg"
                }
            };
        }
    }
}
