using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryWithNoCompositeKeys.Migrations
{
    public partial class address : Migration
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
                    ShippingAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress_HouseNumber = table.Column<int>(type: "int", nullable: true),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "Orders",
                columns: new[] { "Id", "ShippingAddress_City", "ShippingAddress_Country", "ShippingAddress_HouseNumber", "ShippingAddress_Street" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "TestCity", "TestCountry", 3, "TestStreet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "nocompkey");
        }
    }
}
