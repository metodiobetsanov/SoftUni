
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfiguration
{
    class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.SeatingPlace)
                .IsRequired()
                .HasMaxLength(8);

            builder.HasOne(o => o.Trip)
                .WithOne(o => o.)
                .HasForeignKey(k => k.TripId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.CustomerCard)
                .WithMany(m => m.BoughtTickets)
                .HasForeignKey(k => k.CustomerCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
