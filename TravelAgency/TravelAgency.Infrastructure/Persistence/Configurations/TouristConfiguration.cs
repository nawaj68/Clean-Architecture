using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Models;
using TravelAgency.Shared.Enums;

namespace TravelAgency.Infrastructure.Persistence.Configurations;

public class TouristConfiguration : IEntityTypeConfiguration<Tourist>
{
    public void Configure(EntityTypeBuilder<Tourist> builder)
    {
        builder.ToTable("Tourist");
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Name);
        builder.HasData(new
        {
            Id = 1,
            Name="Rubel",
            Email ="r@gmail.com",
            PhoneNumber="0147852369",
            Age ="35",
            JournyDate = new DateTime(1997,01,01),
            Created = DateTimeOffset.Now,
            CreatedBy = "1",
            Status= EntityStatus.Created

        });
        

    }
}
