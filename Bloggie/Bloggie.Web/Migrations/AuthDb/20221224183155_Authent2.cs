using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Authent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bfc168e-ce01-4ae0-94e8-6db06656632f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bf126b7-4a39-457e-a57f-73570c65116a", "AQAAAAEAACcQAAAAEHrGQvulfxI9PquoxeV42kXQONIfYgX9S8zgDs+H8IeeZVeNjuUdoWgQXR1EWZZ6BA==", "8546d5bf-861d-43e7-985c-5539702a36a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bfc168e-ce01-4ae0-94e8-6db06656632f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc43fcf1-1bef-4178-83d5-ce8670f16454", "AQAAAAEAACcQAAAAEHqmGL2koD1vgHgdRIor7oCj54ICvjk9+/ZaSIXcL+yu8ctpWDqxDxxb1i6RiC9hew==", "92c713c6-b75d-418b-b80b-9855f86117df" });
        }
    }
}
