using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(5,2)").IsRequired();

            builder.HasData(
                new Product() {Id = 1, Name = "Spaghetti", UnitPrice = 5m},
                new Product() {Id = 2, Name = "Lasagna", UnitPrice = 10m},
                new Product() {Id = 3, Name = "Ravioli", UnitPrice = 15m}
            );
        }
    }
}