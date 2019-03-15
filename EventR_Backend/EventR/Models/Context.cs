using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventRApi.Models.SeedConf;

namespace EventRApi.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Uzytkownicy> uzytkownicy { get; set; }
        public DbSet<Preferencje> preferencje { get; set; }
        public DbSet<Wydarzenia> wydarzenia { get; set; }
        public DbSet<Komentarze> komentarze { get; set; }
        public DbSet<Grafiki> grafiki { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Wydarzenia>();
            builder.Entity<Uzytkownicy>();
            builder.Entity<Grafiki>();
            builder.Entity<Komentarze>();
            builder.Entity<Preferencje>();

            builder.Seed();
            base.OnModelCreating(builder);

        }
    }
}
