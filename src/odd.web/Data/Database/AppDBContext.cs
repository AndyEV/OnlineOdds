using Microsoft.EntityFrameworkCore;
using odd.web.Data.Domians;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Data.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
           : base(options)
        { }

        public DbSet<Odd> Odds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Team>()
                .HasMany(p => p.Odds)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
        }
    }
}
