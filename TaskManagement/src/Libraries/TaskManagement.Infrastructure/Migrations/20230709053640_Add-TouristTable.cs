using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTouristTable : Migration
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

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 7, 9, 11, 36, 40, 444, DateTimeKind.Unspecified).AddTicks(4908), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Tourist",
                columns: new[] { "Id", "Age", "Created", "CreatedBy", "Email", "JournyDate", "LastModified", "LastModifiedBy", "Name", "PhoneNumber", "Status" },
                values: new object[] { 1, "25", new DateTimeOffset(new DateTime(2023, 7, 9, 11, 36, 40, 441, DateTimeKind.Unspecified).AddTicks(1200), new TimeSpan(0, 6, 0, 0, 0)), "1", "rubel@gmail.com", new DateTime(2023, 7, 9, 11, 36, 40, 441, DateTimeKind.Local).AddTicks(1159), null, null, "Rubel", "017xxxxxx", 1 });

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

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 6, 29, 12, 32, 53, 477, DateTimeKind.Unspecified).AddTicks(3193), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
