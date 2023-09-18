using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models;
using TaskManagement.Shared.Enums;

namespace TaskManagement.Infrastructure.Persistence.Configurations;

internal class UserConfiguration:IEntityTypeConfiguration<Employee>
{
	/// <inheritdoc />
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employee");
		builder.HasKey(x => x.Id);
		builder.HasIndex(entity => new {entity.FirstName , entity.LastName});
        builder.HasData(new
		{
			Id = 1,
			FirstName = "Sumon",
			LastName = "Rahman",
			Email = "sumon@gmail.com",
			Phone ="0190000000",
            Created=DateTimeOffset.Now,
            CreatedBy = "1",
			Status=EntityStatus.Created
		});
	}
}