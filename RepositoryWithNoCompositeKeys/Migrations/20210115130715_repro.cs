using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryWithNoCompositeKeys.Migrations
{
    public partial class repro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nocompkey");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MostImportantOrderLine = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderLineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "nocompkey",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "MostImportantOrderLine" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), 2 });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "OrderLine",
                columns: new[] { "Id", "Description", "OrderId", "OrderLineNumber" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000101"), "ChessSet", new Guid("00000000-0000-0000-0000-000000000001"), 2 });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "OrderLine",
                columns: new[] { "Id", "Description", "OrderId", "OrderLineNumber" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000102"), "NotAChessSet", new Guid("00000000-0000-0000-0000-000000000001"), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                schema: "nocompkey",
                table: "OrderLine",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "nocompkey");
        }
    }
}
