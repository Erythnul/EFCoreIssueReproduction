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
                name: "Company",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupSubGroup",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupAlternateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupSubGroup", x => x.Id);
                    table.UniqueConstraint("AK_CustomerGroupSubGroup_CustomerGroupAlternateKey", x => x.CustomerGroupAlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroup",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupSubGroupAlternateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroup_CustomerGroupSubGroup_CustomerGroupSubGroupAlternateKey",
                        column: x => x.CustomerGroupSubGroupAlternateKey,
                        principalSchema: "nocompkey",
                        principalTable: "CustomerGroupSubGroup",
                        principalColumn: "CustomerGroupAlternateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupSubGroupChild",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupSubGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupSubGroupChildNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupSubGroupChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroupSubGroupChild_CustomerGroupSubGroup_CustomerGroupSubGroupId",
                        column: x => x.CustomerGroupSubGroupId,
                        principalSchema: "nocompkey",
                        principalTable: "CustomerGroupSubGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "nocompkey",
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalSchema: "nocompkey",
                        principalTable: "CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupChild",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupChildNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroupChild_CustomerGroup_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalSchema: "nocompkey",
                        principalTable: "CustomerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "nocompkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntOnOtherSideOfDB = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "nocompkey",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "Company",
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroupSubGroup",
                columns: new[] { "Id", "CustomerGroupAlternateKey" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), 1000 });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroup",
                columns: new[] { "Id", "CustomerGroupSubGroupAlternateKey" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), 1000 });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroupSubGroupChild",
                columns: new[] { "Id", "CustomerGroupSubGroupChildNumber", "CustomerGroupSubGroupId", "Description" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), 1, new Guid("00000000-0000-0000-0000-000000000004"), "Something" });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroupSubGroupChild",
                columns: new[] { "Id", "CustomerGroupSubGroupChildNumber", "CustomerGroupSubGroupId", "Description" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000006"), 2, new Guid("00000000-0000-0000-0000-000000000004"), "SomethingElse" });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "Customer",
                columns: new[] { "Id", "CompanyId", "CustomerGroupId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroupChild",
                columns: new[] { "Id", "CustomerGroupChildNumber", "CustomerGroupId", "Description" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000008"), 1, new Guid("00000000-0000-0000-0000-000000000003"), "Something" });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "CustomerGroupChild",
                columns: new[] { "Id", "CustomerGroupChildNumber", "CustomerGroupId", "Description" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000009"), 2, new Guid("00000000-0000-0000-0000-000000000003"), "SomethingElse" });

            migrationBuilder.InsertData(
                schema: "nocompkey",
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IntOnOtherSideOfDB" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyId",
                schema: "nocompkey",
                table: "Customer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerGroupId",
                schema: "nocompkey",
                table: "Customer",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_CustomerGroupSubGroupAlternateKey",
                schema: "nocompkey",
                table: "CustomerGroup",
                column: "CustomerGroupSubGroupAlternateKey");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupChild_CustomerGroupId",
                schema: "nocompkey",
                table: "CustomerGroupChild",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupSubGroupChild_CustomerGroupSubGroupId",
                schema: "nocompkey",
                table: "CustomerGroupSubGroupChild",
                column: "CustomerGroupSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "nocompkey",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGroupChild",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "CustomerGroupSubGroupChild",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "CustomerGroup",
                schema: "nocompkey");

            migrationBuilder.DropTable(
                name: "CustomerGroupSubGroup",
                schema: "nocompkey");
        }
    }
}
