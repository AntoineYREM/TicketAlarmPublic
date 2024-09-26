using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Common;

namespace TicketAlarm.Application.DTOs.Show
{
    public class ShowDto : BaseShowDto
    {
        public BaseArtistDto? Artist { get; set; }
    }
}
