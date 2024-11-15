using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productswbarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProduct_Products_ProductId_ProductName",
                table: "SaleProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleProduct",
                table: "SaleProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleProduct_ProductId_ProductName",
                table: "SaleProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SaleProduct");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleProduct",
                table: "SaleProduct",
                columns: new[] { "ProductId", "SaleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                table: "SaleProduct",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProduct_Products_ProductId",
                table: "SaleProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleProduct_Products_ProductId",
                table: "SaleProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleProduct",
                table: "SaleProduct");

            migrationBuilder.DropIndex(
                name: "IX_SaleProduct_SaleId",
                table: "SaleProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SaleProduct",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleProduct",
                table: "SaleProduct",
                columns: new[] { "SaleId", "ProductId", "ProductName" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                columns: new[] { "ProductId", "ProductName" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_ProductId_ProductName",
                table: "SaleProduct",
                columns: new[] { "ProductId", "ProductName" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleProduct_Products_ProductId_ProductName",
                table: "SaleProduct",
                columns: new[] { "ProductId", "ProductName" },
                principalTable: "Products",
                principalColumns: new[] { "ProductId", "ProductName" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
