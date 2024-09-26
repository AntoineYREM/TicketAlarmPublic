using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Request.Queries;

namespace TicketAlarm.Application.Features.Artist.Handlers.Queries
{
    public class GetArtistRequestHandler : BaseHandler, IRequestHandler<GetArtistRequest, ArtistDto>
    {
        public GetArtistRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ArtistDto> Handle(GetArtistRequest request, CancellationToken cancellationToken)
        {
            var artist = await UnitOfWork.ArtistRepository.GetSingleAsync(a => a.Id == request.Id);
            return Mapper.Map<ArtistDto>(artist);
        }
    }
}
