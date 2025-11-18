using Domain.CustomEnums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Seeds
{
    public class CarSeed : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new {
                    Id=1, 
                    Model="MX-5", 
                    Price=1000m, 
                    RegistrationDate=new DateTime(2025, 11, 18),
                    State= CarStateEnum.FOR_PARTS,
                    BrandId=1
                },
                new {
                    Id=2,
                    Model="Polo",
                    Price=100m,
                    RegistrationDate = new DateTime(2025, 11, 18),
                    State = CarStateEnum.FOR_PARTS,
                    BrandId=2
                }
            );
        }
    }
}
