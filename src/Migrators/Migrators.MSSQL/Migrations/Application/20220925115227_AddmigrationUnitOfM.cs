using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    public partial class AddmigrationUnitOfM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UoMConversions",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUoMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUoMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Multiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UoMConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UoMConversions_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UoMConversions_UnitOfMeasurement_FromUoMId",
                        column: x => x.FromUoMId,
                        principalSchema: "Catalog",
                        principalTable: "UnitOfMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UoMConversions_UnitOfMeasurement_ToUoMId",
                        column: x => x.ToUoMId,
                        principalSchema: "Catalog",
                        principalTable: "UnitOfMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_FromUoMId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "FromUoMId");

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_ProductId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UoMConversions_ToUoMId",
                schema: "Catalog",
                table: "UoMConversions",
                column: "ToUoMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UoMConversions",
                schema: "Catalog");
        }
    }
}
