using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
    public class StationsDbContext : DbContext
    {
        public StationsDbContext()
        {
        }

        public StationsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CustomerCard> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Station>()
                .HasAlternateKey(k => k.Name);

            modelBuilder.Entity<Train>()
                .HasAlternateKey(k => k.TrainNumber);

            modelBuilder.Entity<SeatingClass>()
                .HasAlternateKey(k => new { k.Name, k.Abbreviation});

            modelBuilder.Entity<Station>()
                .HasMany(m => m.TripsTo)
                .WithOne(o => o.DestinationStation)
                .HasForeignKey(k => k.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>()
                .HasMany(m => m.TripsFrom)
                .WithOne(o => o.OriginStation)
                .HasForeignKey(k => k.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}