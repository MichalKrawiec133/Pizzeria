using Pizzeria.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizzeria.Data.Sql.DAOConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.ProductId).IsRequired();
            builder.Property(c => c.ProductName).IsRequired();
            builder.Property(c => c.ProductIngredients).IsRequired();
            builder.Property(c => c.ProductPrice).IsRequired();
            
            
            
            builder.ToTable("Product");
        }
    }
}