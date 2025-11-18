using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Configurations
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            
            // Columns
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Constraints
            builder.HasKey(b => b.Id).HasName("PK_Brand");

            builder.HasIndex(b => b.Name)
                .IsUnique()
                .HasDatabaseName("UK_Brand_name");
        }
    }
}
