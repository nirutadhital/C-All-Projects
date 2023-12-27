using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReference1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Product",
                newName: "ProductSize");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Product",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Product",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "Product",
                newName: "ProductBrand");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Order",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ProductAddress",
                table: "Order",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductSize",
                table: "Product",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "Product",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Product",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "ProductBrand",
                table: "Product",
                newName: "brand");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Order",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Order",
                newName: "ProductAddress");
        }
    }
}
