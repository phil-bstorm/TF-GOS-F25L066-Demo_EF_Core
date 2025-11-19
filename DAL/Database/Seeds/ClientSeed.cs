using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Database.Seeds
{
    public class ClientSeed : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                new Client() { Id=1, Name="Dupont" },
                new Client() { Id=2, Name="John" },
                new Client() { Id=3, Name="Jane" }
            );
        }
    }
}
