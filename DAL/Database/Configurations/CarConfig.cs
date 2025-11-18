using Domain.CustomEnums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            // Définir le nom de la table
            builder.ToTable("Vrooooom");

            // Colonnes
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Model)
                .IsRequired() // not null
                .HasMaxLength(50); // varchar(50)

            builder.Property(c => c.Price)
                .IsRequired()
                .HasPrecision(9, 2); // précision du numéric

            builder.Property(c => c.RegistrationDate)
                .HasColumnType("date");

            builder.Property(c => c.State)
                .IsRequired()
                .HasConversion<string>(); // conversion de l'enum en string

            // Contraintes
            builder.HasKey(c => c.Id)
                .HasName("PK_Car");

            builder.ToTable(t =>
                t.HasCheckConstraint("CK_Car__Price", "[Price] >= 0")
            );

            // Relations
            builder.HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey("BrandId")
                .IsRequired();
        }
    }
}
