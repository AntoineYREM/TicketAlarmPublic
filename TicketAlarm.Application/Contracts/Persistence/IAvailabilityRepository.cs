using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Contracts.Persistence
{
    public interface IAvailabilityRepository : IGenericRepository<Availability>
    {
    }
}
