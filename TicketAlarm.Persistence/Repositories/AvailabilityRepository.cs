using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Domain;

namespace TicketAlarm.Persistence.Repositories
{
    public class AvailabilityRepository : GenericRepository<Availability>, IAvailabilityRepository
    {
        public AvailabilityRepository(TicketAlarmDbContext context) : base(context)
        {
        }
    }
}
