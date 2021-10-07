using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Services.RefillAPI.Migrations
{
    public partial class ADDuserIDtoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Subscription_ID",
                table: "RefillStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subscription_ID",
                table: "RefillStatuses");
        }
    }
}
