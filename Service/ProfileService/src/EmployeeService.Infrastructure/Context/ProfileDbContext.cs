using ProfileService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Infrastructure.Context
{
    public class ProfileDbContext: DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> option): base(option)
        {
        }
        public virtual DbSet<Profile> Profiles { get; set; }
    }
}
