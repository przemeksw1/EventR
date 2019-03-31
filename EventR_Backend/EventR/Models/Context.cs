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

        public DbSet<User> users { get; set; }
        public DbSet<Preference> preferences { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Image> images { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Event>();
            builder.Entity<User>();
            builder.Entity<Image>();
            builder.Entity<Comment>();
            builder.Entity<Preference>();

            builder.Seed();
            base.OnModelCreating(builder);

        }
    }
}
