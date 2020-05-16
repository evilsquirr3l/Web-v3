using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Implementation.EntityConfigurations
{
    public class ApartmentResidentsConfig : IEntityTypeConfiguration<ApartmentResidents>
    {
        public void Configure(EntityTypeBuilder<ApartmentResidents> builder)
        {
            builder.HasKey(x => new {x.ApartmentId, x.ResidentId});

            builder.HasOne(x => x.Apartment)
                .WithMany(x => x.Residents)
                .HasForeignKey(x => x.ApartmentId);

            builder.HasOne(x => x.Resident)
                .WithMany(x => x.Apartments)
                .HasForeignKey(x => x.ResidentId);
        }
    }
}