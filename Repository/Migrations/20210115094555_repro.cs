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
                name: "Company",
                schema: "compkey",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupSubGroup",
                schema: "compkey",
                columns: table => new
                {
                    CustomerSubGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupAlternateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupSubGroup", x => x.CustomerSubGroupId);
                    table.UniqueConstraint("AK_CustomerGroupSubGroup_CustomerGroupAlternateKey", x => x.CustomerGroupAlternateKey);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroup",
                schema: "compkey",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerGroupId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupSubGroupAlternateKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroup", x => new { x.CompanyId, x.CustomerGroupId });
                    table.ForeignKey(
                        name: "FK_CustomerGroup_CustomerGroupSubGroup_CustomerGroupSubGroupAlternateKey",
                        column: x => x.CustomerGroupSubGroupAlternateKey,
                        principalSchema: "compkey",
                        principalTable: "CustomerGroupSubGroup",
                        principalColumn: "CustomerGroupAlternateKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupSubGroupChild",
                schema: "compkey",
                columns: table => new
                {
                    CustomerGroupSubGroupId = table.Column<int>(type: "int", nullable: false),
                    CustomerGroupSubGroupChildId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupSubGroupChildNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupSubGroupChild", x => new { x.CustomerGroupSubGroupId, x.CustomerGroupSubGroupChildId });
                    table.ForeignKey(
                        name: "FK_CustomerGroupSubGroupChild_CustomerGroupSubGroup_CustomerGroupSubGroupId",
                        column: x => x.CustomerGroupSubGroupId,
                        principalSchema: "compkey",
                        principalTable: "CustomerGroupSubGroup",
                        principalColumn: "CustomerSubGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "compkey",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => new { x.CompanyId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Customer_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "compkey",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerGroup_CompanyId_CustomerGroupId",
                        columns: x => new { x.CompanyId, x.CustomerGroupId },
                        principalSchema: "compkey",
                        principalTable: "CustomerGroup",
                        principalColumns: new[] { "CompanyId", "CustomerGroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerGroupChild",
                schema: "compkey",
                columns: table => new
                {
                    CustomerGroupId = table.Column<int>(type: "int", nullable: false),
                    CustomerGroupChildId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerGroupChildNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerGroupCompanyId = table.Column<int>(type: "int", nullable: true),
                    CustomerGroupId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupChild", x => new { x.CustomerGroupId, x.CustomerGroupChildId });
                    table.ForeignKey(
                        name: "FK_CustomerGroupChild_CustomerGroup_CustomerGroupCompanyId_CustomerGroupId1",
                        columns: x => new { x.CustomerGroupCompanyId, x.CustomerGroupId1 },
                        principalSchema: "compkey",
                        principalTable: "CustomerGroup",
                        principalColumns: new[] { "CompanyId", "CustomerGroupId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "compkey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerParentCompanyId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IntOnOtherSideOfDB = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerParentCompanyId_CustomerId",
                        columns: x => new { x.CustomerParentCompanyId, x.CustomerId },
                        principalSchema: "compkey",
                        principalTable: "Customer",
                        principalColumns: new[] { "CompanyId", "CustomerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "Company",
                columns: new[] { "CompanyId", "Id" },
                values: new object[] { 1, new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "CustomerGroupChild",
                columns: new[] { "CustomerGroupChildId", "CustomerGroupId", "CustomerGroupChildNumber", "CustomerGroupCompanyId", "CustomerGroupId1", "Description", "Id" },
                values: new object[,]
                {
                    { 301, 3, 1, null, null, "Something", new Guid("00000000-0000-0000-0000-000000000008") },
                    { 302, 3, 2, null, null, "SomethingElse", new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "CustomerGroupSubGroup",
                columns: new[] { "CustomerSubGroupId", "CustomerGroupAlternateKey", "Id" },
                values: new object[] { 100, 1000, new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "CustomerGroup",
                columns: new[] { "CompanyId", "CustomerGroupId", "CustomerGroupSubGroupAlternateKey", "Id" },
                values: new object[] { 1, 3, 1000, new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "CustomerGroupSubGroupChild",
                columns: new[] { "CustomerGroupSubGroupChildId", "CustomerGroupSubGroupId", "CustomerGroupSubGroupChildNumber", "Description", "Id" },
                values: new object[] { 101, 100, 1, "Something", new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "CustomerGroupSubGroupChild",
                columns: new[] { "CustomerGroupSubGroupChildId", "CustomerGroupSubGroupId", "CustomerGroupSubGroupChildNumber", "Description", "Id" },
                values: new object[] { 102, 100, 2, "SomethingElse", new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "Customer",
                columns: new[] { "CompanyId", "CustomerId", "CustomerGroupId", "Id" },
                values: new object[] { 1, 2, 3, new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.InsertData(
                schema: "compkey",
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "CustomerParentCompanyId", "IntOnOtherSideOfDB", "OrderId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 2, 1, 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CompanyId_CustomerGroupId",
                schema: "compkey",
                table: "Customer",
                columns: new[] { "CompanyId", "CustomerGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroup_CustomerGroupSubGroupAlternateKey",
                schema: "compkey",
                table: "CustomerGroup",
                column: "CustomerGroupSubGroupAlternateKey");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupChild_CustomerGroupCompanyId_CustomerGroupId1",
                schema: "compkey",
                table: "CustomerGroupChild",
                columns: new[] { "CustomerGroupCompanyId", "CustomerGroupId1" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerParentCompanyId_CustomerId",
                schema: "compkey",
                table: "Orders",
                columns: new[] { "CustomerParentCompanyId", "CustomerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGroupChild",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "CustomerGroupSubGroupChild",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "CustomerGroup",
                schema: "compkey");

            migrationBuilder.DropTable(
                name: "CustomerGroupSubGroup",
                schema: "compkey");
        }
    }
}
