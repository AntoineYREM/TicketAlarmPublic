using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Show.Requests.Queries;
using static System.Formats.Asn1.AsnWriter;

namespace TicketAlarm.Application.Features.Show.Handlers.Queries
{
    public class GetShowsRequestHandler : BaseHandler ,IRequestHandler<GetShowsRequest, List<ShowDto>>
    {
        public GetShowsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<ShowDto>> Handle(GetShowsRequest request, CancellationToken cancellationToken)
        {
            var shows = await UnitOfWork.ShowRepository.GetAllAsync(s => s.Include(s => s.Alarms).Include(s => s.Artist));

            var tshows = shows
                .GroupBy(s => s.IdArtist)
                .Select(s => s.OrderByDescending(s => s.Alarms.Count()).First()).ToList()
                .OrderByDescending(s => s.Alarms.Count())
            .Take(6);

            //var test = shows
            //    .GroupBy(s => s.IdArtist)
            //    .Select(s => s.OrderByDescending(s => s.Alarms.Count()).First())
            //            .Select(s => new
            //            {
            //                show = s,
            //                alarm = s.Alarms.OrderByDescending(d => d.Note).FirstOrDefault() // Récupérer le devoir avec la note la plus haute
            //            })
            //            .OrderByDescending(x => x.MeilleurDevoir.Note) // Trier par la meilleure note de chaque étudiant
            //            .Take(2) // Prendre les 2 meilleurs étudiants
            //            .ToList();

            //var solution = await UnitOfWork.ArtistRepository.GetAllAsync(a => a.Include(a => a.Shows))

            return Mapper.Map<List<ShowDto>>(tshows);
        }
    }
}
