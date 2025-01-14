using Microsoft.EntityFrameworkCore;
using GameFlow.Domain.Entities;

namespace GameFlow.Infrastructure
{
    public class GameFlowDbContext : DbContext
    {
        public GameFlowDbContext(DbContextOptions<GameFlowDbContext> options) : base(options) { }

        public DbSet<Client>? Clients { get; set; }
        public DbSet<Game>? Games { get; set; }
        public DbSet<Subscription>? Subscriptions { get; set; }
        public DbSet<Rental>? Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Game)
                .WithMany(g => g.Rentals)
                .HasForeignKey(r => r.GameId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.ClientId);
        }
    }
}
