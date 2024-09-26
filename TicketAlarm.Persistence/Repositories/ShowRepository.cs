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
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        public ShowRepository(TicketAlarmDbContext context) : base(context)
        {
        }
    }
}
