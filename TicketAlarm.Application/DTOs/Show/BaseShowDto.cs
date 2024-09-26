using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Common;

namespace TicketAlarm.Application.DTOs.Show
{
    public class BaseShowDto : BaseDto
    {
        public int Id { get; set; }
        public int IdArtist { get; set; }
        public string Title { get; set; }
        public DateTime DateTimeShow { get; set; }
        public int IdFnac { get; set; }
        public string City { get; set; }
        public string Arena { get; set; }
        public string Url { get; set; }
        public bool Available { get; set; }
    }
}
