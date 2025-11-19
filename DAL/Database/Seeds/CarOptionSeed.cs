using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Seeds
{
    public class CarOptionSeed : IEntityTypeConfiguration<CarOption>
    {
        public void Configure(EntityTypeBuilder<CarOption> builder)
        {
            builder.HasData(
                new CarOption() { Id = 1, Name="Clignotant" },
                new CarOption() { Id = 2, Name = "Siège chauffant" },
                new CarOption() { Id = 3, Name = "Ouverture de proximité" }
            );
        }
    }
}
