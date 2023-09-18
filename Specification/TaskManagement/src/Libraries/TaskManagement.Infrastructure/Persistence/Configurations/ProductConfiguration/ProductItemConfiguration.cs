using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models;

namespace TaskManagement.Infrastructure.Persistence.Configurations.ProductConfiguration;

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    void IEntityTypeConfiguration<ProductItem>.Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.ToTable("ProductItems");
        builder.HasKey(x => x.Id);
        builder.HasOne(e => e.Product)
        .WithMany(e => e.ProductItems).HasForeignKey(e=>e.ProductId)
        .IsRequired();

    }
}