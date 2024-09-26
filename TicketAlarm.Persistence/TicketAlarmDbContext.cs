using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;

namespace TicketAlarm.Persistence
{
    public class TicketAlarmDbContext : DbContext
    {

        //public TicketAlarmDbContext() : base()
        //{

        //}

        public TicketAlarmDbContext(DbContextOptions<TicketAlarmDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TicketAlarmDbContext).Assembly);
        }

        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Availability> Availabilitys { get; set; }
    }
}
