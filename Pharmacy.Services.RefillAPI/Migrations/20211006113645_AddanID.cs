using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Services.RefillAPI.Migrations
{
    public partial class AddanID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdhocRefillId",
                table: "RefillStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdhocRefillId",
                table: "RefillStatuses");
        }
    }
}
