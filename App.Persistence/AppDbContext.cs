using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<EventType> EventTypes { get; set; } = default!;
        public DbSet<OperationClaim> OperationClaims { get; set; } = default!;
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; } = default!;
        public DbSet<Venue> Venues { get; set; } = default!;
        public DbSet<Ticket> Tickets { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<District> Districts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasQueryFilter(e => e.IsStatus);
            modelBuilder.Entity<District>().HasQueryFilter(u => u.IsStatus);
            modelBuilder.Entity<Event>().HasQueryFilter(e => e.IsStatus);
            modelBuilder.Entity<EventType>().HasQueryFilter(e => e.IsStatus);
            modelBuilder.Entity<OperationClaim>().HasQueryFilter(u => u.IsStatus);
            modelBuilder.Entity<Ticket>().HasQueryFilter(e => e.IsStatus);
            modelBuilder.Entity<User>().HasQueryFilter(u => u.IsStatus);
            modelBuilder.Entity<UserOperationClaim>().HasQueryFilter(u => u.IsStatus);
            modelBuilder.Entity<Venue>().HasQueryFilter(e => e.IsStatus);
        }
    }
}
