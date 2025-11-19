using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Configurations
{
    public class RentConfig : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rent");

            builder.Property(r => r.Id)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.HasKey(r => r.Id)
                .HasName("PK_Rent");

            // rent possede une voiture ; voiture peut avoir plusieurs rent
            // ONE TO MANY
            builder.HasOne(r => r.Car)
                .WithMany(c => c.Rents)
                .HasForeignKey("CarId")
                .IsRequired();

            // rent possede un client ; client peut avoir plusieurs rent
            // ONE TO MANY
            builder.HasOne(r => r.Client)
                .WithMany(c => c.Rents)
                .HasForeignKey("ClientId")
                .IsRequired();
        }
    }
}
