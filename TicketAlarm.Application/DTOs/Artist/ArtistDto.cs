using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Common;
using TicketAlarm.Application.DTOs.Show;

namespace TicketAlarm.Application.DTOs.Artist
{
    public class ArtistDto : BaseArtistDto
    {
        public ICollection<BaseShowDto> Shows { get; set; }
    }
}
