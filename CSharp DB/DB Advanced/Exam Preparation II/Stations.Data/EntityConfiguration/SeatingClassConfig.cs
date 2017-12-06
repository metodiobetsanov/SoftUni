
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stations.Models;

namespace Stations.Data.EntityConfiguration
{
    class SeatingClassConfig : IEntityTypeConfiguration<SeatingClass>
    {
        public void Configure(EntityTypeBuilder<SeatingClass> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                ;

            builder.Property(p => p.Abbreviation)
                .IsRequired()
                .IsUnicode();
        }
    }
}
