using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Infrastructure.Persistence.Configurations
{
    internal class CompanyConfiguration : IEntityTypeConfiguration<Companies>
    {
        public void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(x => x.Id);
            builder.HasData(new
            {
                Id = 1,
                CompanyName = "Test",
                Address = "Dhaka",
                Owner = "Tamjid",
                Created = DateTimeOffset.Now,
                CreatedBy = "1",
                Status = EntityStatus.Created
            });
        }
    }

}
