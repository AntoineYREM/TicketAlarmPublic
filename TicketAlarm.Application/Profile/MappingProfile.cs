

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
            CreateMap<Alarm, AlarmDto>().ForMember(a => a.IdAlarm, opt => opt.MapFrom(a => a.Id)).ReverseMap();
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<Show, ShowDto>().ReverseMap();
            CreateMap<Artist, BaseArtistDto>().ReverseMap();
            CreateMap<Show, BaseShowDto>().ReverseMap();
            CreateMap<Availability, AvailabilityDto>().ReverseMap();
        }
    }
}
