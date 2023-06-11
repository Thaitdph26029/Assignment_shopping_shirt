using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_shopping_shirt.Migrations
{
    public partial class Net104_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product",
                table: "CartDetails");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product",
                table: "CartDetails",
                column: "ProductID",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Product",
                table: "CartDetails",
                column: "Id",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
