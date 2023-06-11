using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_shopping_shirt.Migrations
{
    public partial class Net104_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_ProductDetails_ID",
                table: "BillDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ProductID",
                table: "BillDetails",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_ProductDetails_ProductID",
                table: "BillDetails",
                column: "ProductID",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_ProductDetails_ProductID",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_ProductID",
                table: "BillDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_ProductDetails_ID",
                table: "BillDetails",
                column: "ID",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
