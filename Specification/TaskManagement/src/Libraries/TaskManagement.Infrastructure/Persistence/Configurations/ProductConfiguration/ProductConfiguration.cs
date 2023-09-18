using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Infrastructure.Persistence.Configurations.ProductConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.HasData(new
        {
            Id = 1,
            ProductName="Hp-Laptop",
            ProductDescription="Hp New Laptop.",
            ProductPrice=50000.00,
            ProductColor="Black",
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            Status = EntityStatus.Created
        });
    }
}
