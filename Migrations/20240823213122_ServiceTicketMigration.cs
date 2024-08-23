using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Migrations
{
    /// <inheritdoc />
    public partial class ServiceTicketMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceTicket",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MechanicId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceStatusId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PriceTotal = table.Column<float>(type: "REAL", nullable: false),
                    CaseDescription = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicket", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTicket");
        }
    }
}
