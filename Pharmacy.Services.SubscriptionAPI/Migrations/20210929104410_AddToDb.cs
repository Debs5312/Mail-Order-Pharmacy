using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Services.SubscriptionAPI.Migrations
{
    public partial class AddToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Insurance_policy_number = table.Column<int>(type: "int", nullable: false),
                    Insurance_Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prescription_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prescription_Id = table.Column<int>(type: "int", nullable: false),
                    Drug_ID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscription_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Refill_Occurrence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
