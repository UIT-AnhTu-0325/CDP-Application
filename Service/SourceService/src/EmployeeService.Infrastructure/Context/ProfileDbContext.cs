using SourceService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceService.Infrastructure.Context
{
    public class SourceDbContext: DbContext
    {
        public SourceDbContext(DbContextOptions<SourceDbContext> option): base(option)
        {
        }
        public virtual DbSet<Source> Sources { get; set; }
    }
}
