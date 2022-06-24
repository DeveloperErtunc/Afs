using AFS.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS.Data.Context
{
    public class AFSContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public AFSContext(DbContextOptions<AFSContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TranslateData> TranslateDatas { get; set; }
        public DbSet<LogBusiness> LogBusiness { get; set; }
    }
}
