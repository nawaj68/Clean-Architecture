using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Models;
using TaskManagement.Shared.Enums;

namespace TaskManagement.DataAccess.Configurations;

internal class UserConfiguration:IEntityTypeConfiguration<Employee>
{
	/// <inheritdoc />
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("User");
		builder.HasKey(x => x.Id);
		builder.HasIndex(entity => new {entity.FirstName , entity.LastName});
		builder.HasIndex(e=>e.UserName).IsUnique();
		builder.HasData(new
		{
			Id = 1,
			FirstName = "Sumon",
			LastName = "Rahman",
			Email = "sumon@gmail.com",
			Phone ="0190000000",
			UserName="sumon",
			Password = "12345",
			CreateDate=DateTimeOffset.Now,
			CreatedBy = "1",
			Status=EntityStatus.Created
		});
	}
}