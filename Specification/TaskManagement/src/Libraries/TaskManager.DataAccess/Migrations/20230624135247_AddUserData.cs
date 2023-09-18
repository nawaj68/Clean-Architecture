using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Created", "CreatedBy", "Email", "FirstName", "LastName", "Password", "Phone", "Status", "LastModified", "LastModifiedBy", "UserName" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2023, 6, 24, 19, 52, 47, 617, DateTimeKind.Unspecified).AddTicks(3355), new TimeSpan(0, 6, 0, 0, 0)), "1", "sumon@gmail.com", "Sumon", "Rahman", "12345", "0190000000", 1, null, null, "sumon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
