using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Seeds
{
    public class RentSeed : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasData(
                new { Id=1, ClientId=2, CarId = 2, CreatedAt=new DateTime(2025, 11, 19) }    
            );
        }
    }
}
