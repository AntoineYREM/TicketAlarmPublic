using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Common;

namespace TicketAlarm.Application.DTOs.Artist
{
    public class ArtistDto : BaseDto
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
    }
}
