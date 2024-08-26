using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Migrations
{
    /// <inheritdoc />
    public partial class CalculatedRepairCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatedRepairCost",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartQuantity = table.Column<int>(type: "int", nullable: false),
                    HoursDedicated = table.Column<int>(type: "int", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatedRepairCost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarPart",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarPartName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    PricePerUnit = table.Column<float>(type: "real", nullable: false),
                    OrderStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChargedCar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Kwh = table.Column<float>(type: "real", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargedCar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientCar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    HourlyRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatusName = table.Column<int>(type: "int", nullable: false),
                    QuantityOrdered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RefueledCar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Litres = table.Column<float>(type: "real", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefueledCar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceStatusName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTicket",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false),
                    CaseDescription = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTicket", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatedRepairCost");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarPart");

            migrationBuilder.DropTable(
                name: "ChargedCar");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientCar");

            migrationBuilder.DropTable(
                name: "Mechanic");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "RefueledCar");

            migrationBuilder.DropTable(
                name: "ServiceStatus");

            migrationBuilder.DropTable(
                name: "ServiceTicket");

            migrationBuilder.DropTable(
                name: "ServiceType");
        }
    }
}
