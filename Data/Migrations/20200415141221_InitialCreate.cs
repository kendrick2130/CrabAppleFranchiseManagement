using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FranchiseManagement.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTime = table.Column<DateTime>(nullable: false),
                    PriceTotal = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    FoodTruckID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "FoodTrucks",
                columns: table => new
                {
                    FoodTruckID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LocationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTrucks", x => x.FoodTruckID);
                    table.ForeignKey(
                        name: "FK_FoodTrucks_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTruckID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_FoodTrucks_FoodTruckID",
                        column: x => x.FoodTruckID,
                        principalTable: "FoodTrucks",
                        principalColumn: "FoodTruckID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(15,4)", nullable: false),
                    FoodItemDescription = table.Column<string>(nullable: true),
                    FoodTruckID = table.Column<int>(nullable: true),
                    OrderID = table.Column<int>(nullable: true),
                    TransactionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodItemID);
                    table.ForeignKey(
                        name: "FK_FoodItems_FoodTrucks_FoodTruckID",
                        column: x => x.FoodTruckID,
                        principalTable: "FoodTrucks",
                        principalColumn: "FoodTruckID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodItems_Transactions_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transactions",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_FoodTruckID",
                table: "FoodItems",
                column: "FoodTruckID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_OrderID",
                table: "FoodItems",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_TransactionID",
                table: "FoodItems",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTrucks_LocationID",
                table: "FoodTrucks",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodTruckID",
                table: "Orders",
                column: "FoodTruckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "FoodTrucks");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
