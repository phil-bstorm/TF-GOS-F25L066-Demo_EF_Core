using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Configurations
{
    public class CarOptionConfig : IEntityTypeConfiguration<CarOption>
    {
        public void Configure(EntityTypeBuilder<CarOption> builder)
        {
            builder.ToTable("CarOption");

            #region Propriétés
            builder.Property(co => co.Id)
                .ValueGeneratedOnAdd();

            builder.Property(co => co.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region Contraintes
            builder.HasKey(co => co.Id)
                .HasName("PK_CarOption");

            builder.HasIndex(co => co.Name)
                .IsUnique();
            #endregion
        }
    }
}
