using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Migrations
{
    /// <inheritdoc />
    public partial class CalculatedRepairCost1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedRepairCost",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartQuantity = table.Column<int>(type: "int", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedRepairCost", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedRepairCost");
        }
    }
}
