using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "LastName", "Mobile", "Name" },
                values: new object[] { 1, "رحمتی", "09481317468", "صدرالدین" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: 1);
        }
    }
}
