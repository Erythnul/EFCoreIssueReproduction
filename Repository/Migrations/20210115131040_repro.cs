using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryWithCompositeKeys.Migrations
{
    public partial class repro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "compkey");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "compkey",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MostImportantOrderLine = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => new { x.CompanyId, x.CustomerId, x.OrderId });
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                schema: "compkey",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderLineId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderLineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => new { x.CompanyId, x.CustomerId, x.OrderId, x.OrderLineId });
                    table.ForeignKey(
                        name: "FK_OrderLine_Orders_CompanyId_CustomerId_OrderId",
                        columns: x => new { x.CompanyId, x.CustomerId, x.OrderId },
                        principalSchema: "compkey",
                        principalTable: "Orders",
                        principalColumns: new[] { "CompanyId", "CustomerId", "OrderId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "Orders",
                columns: new[] { "CompanyId", "CustomerId", "OrderId", "Id", "MostImportantOrderLine" },
                values: new object[] { 1, 2, 1, new Guid("00000000-0000-0000-0000-000000000001"), 2 });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "OrderLine",
                columns: new[] { "CompanyId", "CustomerId", "OrderId", "OrderLineId", "Description", "Id", "OrderLineNumber" },
                values: new object[] { 1, 2, 1, 1, "ChessSet", new Guid("00000000-0000-0000-0000-000000000101"), 2 });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "OrderLine",
                columns: new[] { "CompanyId", "CustomerId", "OrderId", "OrderLineId", "Description", "Id", "OrderLineNumber" },
                values: new object[] { 1, 2, 1, 2, "NotAChessSet", new Guid("00000000-0000-0000-0000-000000000102"), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "compkey");
        }
    }
}
