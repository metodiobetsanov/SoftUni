
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfiguration
{
    class TrainConfig : IEntityTypeConfiguration<Train>
    {
        public void Configure(EntityTypeBuilder<Train> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.TrainNumber)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(10);
        }
    }
}
