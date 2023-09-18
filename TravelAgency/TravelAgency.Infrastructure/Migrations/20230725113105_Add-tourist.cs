using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addtourist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tourist",
                columns: new[] { "Id", "Age", "Created", "CreatedBy", "Email", "JournyDate", "LastModified", "LastModifiedBy", "Name", "PhoneNumber", "Status" },
                values: new object[] { 1, "35", new DateTimeOffset(new DateTime(2023, 7, 25, 17, 31, 5, 363, DateTimeKind.Unspecified).AddTicks(7601), new TimeSpan(0, 6, 0, 0, 0)), "1", "r@gmail.com", new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Rubel", "0147852369", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Tourist_Name",
                table: "Tourist",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tourist");
        }
    }
}
