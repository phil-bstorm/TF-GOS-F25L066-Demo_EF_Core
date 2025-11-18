using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Seeds
{
    public class BrandSeed : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand() { Id=1, Name= "Mazda"},
                new Brand() { Id=2, Name="VW"}
            );
        }
    }
}
