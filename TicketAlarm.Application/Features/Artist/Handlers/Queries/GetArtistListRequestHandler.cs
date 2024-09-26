using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.Features.Request.Queries;

namespace TicketAlarm.Application.Features.Artist.Handlers.Queries
{
    public class GetArtistListRequestHandler : BaseHandlerArtist, IRequestHandler<GetArtistListRequest, List<ArtistDto>>
    {
        public GetArtistListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async  Task<List<ArtistDto>> Handle(GetArtistListRequest request, CancellationToken cancellationToken)
        {
            var artists = await UnitOfWork.ArtistRepository.GetAllAsync();
            return Mapper.Map<List<ArtistDto>>(artists.ToList());
        }
    }
}
