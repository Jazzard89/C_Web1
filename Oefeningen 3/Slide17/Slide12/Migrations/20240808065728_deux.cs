using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slide12.Migrations
{
    public partial class deux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResellerStock_Products_ProductId",
                table: "ResellerStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ResellerStock_Resellers_ResellerId",
                table: "ResellerStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResellerStock",
                table: "ResellerStock");

            migrationBuilder.RenameTable(
                name: "ResellerStock",
                newName: "ResellerStocks");

            migrationBuilder.RenameIndex(
                name: "IX_ResellerStock_ResellerId",
                table: "ResellerStocks",
                newName: "IX_ResellerStocks_ResellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ResellerStock_ProductId",
                table: "ResellerStocks",
                newName: "IX_ResellerStocks_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResellerStocks",
                table: "ResellerStocks",
                column: "ResellerStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellerStocks_Products_ProductId",
                table: "ResellerStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResellerStocks_Resellers_ResellerId",
                table: "ResellerStocks",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "ResellerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResellerStocks_Products_ProductId",
                table: "ResellerStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ResellerStocks_Resellers_ResellerId",
                table: "ResellerStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResellerStocks",
                table: "ResellerStocks");

            migrationBuilder.RenameTable(
                name: "ResellerStocks",
                newName: "ResellerStock");

            migrationBuilder.RenameIndex(
                name: "IX_ResellerStocks_ResellerId",
                table: "ResellerStock",
                newName: "IX_ResellerStock_ResellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ResellerStocks_ProductId",
                table: "ResellerStock",
                newName: "IX_ResellerStock_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResellerStock",
                table: "ResellerStock",
                column: "ResellerStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellerStock_Products_ProductId",
                table: "ResellerStock",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResellerStock_Resellers_ResellerId",
                table: "ResellerStock",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "ResellerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
