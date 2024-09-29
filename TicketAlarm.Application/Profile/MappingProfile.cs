

using AutoMapper;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Availability;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Alarm, AlarmDto>().ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<Show, ShowDto>().ReverseMap();
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
        }
    }
}
