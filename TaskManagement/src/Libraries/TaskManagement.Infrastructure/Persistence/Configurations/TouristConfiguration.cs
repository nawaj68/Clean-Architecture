using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Infrastructure.Persistence.Configurations
{
    public class TouristConfiguration : IEntityTypeConfiguration<Tourist>
    {
        public void Configure(EntityTypeBuilder<Tourist> builder)
        {
            builder.ToTable(nameof(Tourist));
            builder.HasKey(t => t.Id);
            builder.HasIndex(entity => new {entity.Name});
            builder.HasData(new
            {
                Id=1,
                Name="Rubel",
                Email="rubel@gmail.com",
                PhoneNumber="017xxxxxx",
                Age="25",
                JournyDate=DateTime.Now,
                Created = DateTimeOffset.Now,
                CreatedBy = "1",
                Status = EntityStatus.Created
            });
        }
    }
}
