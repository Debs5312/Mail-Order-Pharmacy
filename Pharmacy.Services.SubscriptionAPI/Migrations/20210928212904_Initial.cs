using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Services.SubscriptionAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mfgdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PricePerPackage = table.Column<double>(type: "float", nullable: false),
                    UnitInPackage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugDispatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    IsDispatched = table.Column<bool>(type: "bit", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDispatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugDispatches_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Drug_Id = table.Column<int>(type: "int", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Drugs_Drug_Id",
                        column: x => x.Drug_Id,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prescription_Id = table.Column<int>(type: "int", nullable: true),
                    Drug_ID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscription_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Refill_Occurrence = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Prescriptions_Prescription_Id",
                        column: x => x.Prescription_Id,
                        principalTable: "Prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugDispatches_DrugId",
                table: "DrugDispatches",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_Drug_Id",
                table: "Prescriptions",
                column: "Drug_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Prescription_Id",
                table: "Subscriptions",
                column: "Prescription_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugDispatches");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
