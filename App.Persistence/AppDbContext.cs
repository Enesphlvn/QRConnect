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
        }
    }
}
