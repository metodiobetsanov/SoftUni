
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfiguration
{
    class TrainSeatConfig : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasOne(e => e.Train)
                .WithMany(m => m.TrainSeats)
                .HasForeignKey(k => k.TrainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.SeatingClass)
                .WithMany(m => m.TrainSeats)
                .HasForeignKey(k => k.SeatingClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
