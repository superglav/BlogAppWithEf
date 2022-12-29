using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bfc168e-ce01-4ae0-94e8-6db06656632f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d00b23c7-83c0-4b5b-ab83-3c834dbdc9fa", "SUPERADMIN@BLOGIE.COM", "SUPERADMIN@BLOGIE.COM", "AQAAAAEAACcQAAAAEFcd0w7iYv3oAGdo+iJQZashOGoueXFr7feTUeEyDrfnOEdNk+VsP/NhSicLrUoFjg==", "db315278-5702-475f-a717-af916fd7ce6b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bfc168e-ce01-4ae0-94e8-6db06656632f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e35e4e3-8b53-4e95-949f-154889611de8", null, null, "AQAAAAEAACcQAAAAEA1RjfN5FXzdlmpY4N272YI5scVsNTG6f8GbH6bDRjr8dgewRQHl/++Vs1Y43jCfeA==", "c6a6440c-d9e8-4364-a9fb-93329922fea7" });
        }
    }
}
