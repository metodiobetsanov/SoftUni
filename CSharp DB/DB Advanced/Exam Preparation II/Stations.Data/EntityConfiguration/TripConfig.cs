
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfiguration
{
    class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.DepartureTime)
                .IsRequired();

            builder.Property(p => p.ArrivalTime)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();


            builder.HasOne(o => o.OriginStation)
                .WithMany(m => m.TripsFrom)
                .HasForeignKey(k => k.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.DestinationStation)
                .WithMany(m => m.TripsTo)
                .HasForeignKey(k => k.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Train)
                .WithMany(m => m.Trips)
                .HasForeignKey(k => k.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
