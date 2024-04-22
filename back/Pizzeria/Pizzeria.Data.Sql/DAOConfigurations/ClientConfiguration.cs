using Pizzeria.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizzeria.Data.Sql.DAOConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.ClientId).IsRequired();
            builder.Property(c => c.ClientFirstName).IsRequired();
            builder.Property(c => c.ClientLastName).IsRequired();
            builder.Property(c => c.ClientPesel).IsRequired();
            builder.Property(c => c.ClientEmail).IsRequired();
            builder.Property(c => c.ClientHash).IsRequired();
            builder.Property(c => c.ClientRole).IsRequired();
            builder.ToTable("Client");
        }
    }
}