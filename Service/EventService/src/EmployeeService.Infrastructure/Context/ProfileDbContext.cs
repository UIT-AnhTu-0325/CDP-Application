using EventService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService.Infrastructure.Context
{
    public class EventDbContext: DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> option): base(option)
        {
        }
        public virtual DbSet<Event> Events { get; set; }
    }
}
