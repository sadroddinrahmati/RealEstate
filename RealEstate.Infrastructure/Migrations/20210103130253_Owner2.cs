using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Infrastructure.Migrations
{
    public partial class Owner2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "ترابی", "محمد رضا" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "رحمتی", "صدرالدین" });
        }
    }
}
