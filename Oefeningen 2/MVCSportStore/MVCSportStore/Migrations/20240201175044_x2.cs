using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCSportStore.Migrations
{
    public partial class x2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResellersStock_Products_ProductId",
                table: "ResellersStock");

            migrationBuilder.DropForeignKey(
                name: "FK_ResellersStock_Resellers_ResellerId",
                table: "ResellersStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResellersStock",
                table: "ResellersStock");

            migrationBuilder.RenameTable(
                name: "ResellersStock",
                newName: "ResellersStocks");

            migrationBuilder.RenameIndex(
                name: "IX_ResellersStock_ResellerId",
                table: "ResellersStocks",
                newName: "IX_ResellersStocks_ResellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ResellersStock_ProductId",
                table: "ResellersStocks",
                newName: "IX_ResellersStocks_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "ResellerGuid",
                table: "ResellersStocks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResellersStocks",
                table: "ResellersStocks",
                column: "ResellerStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellersStocks_Products_ProductId",
                table: "ResellersStocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellersStocks_Resellers_ResellerId",
                table: "ResellersStocks",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "ResellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResellersStocks_Products_ProductId",
                table: "ResellersStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ResellersStocks_Resellers_ResellerId",
                table: "ResellersStocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResellersStocks",
                table: "ResellersStocks");

            migrationBuilder.DropColumn(
                name: "ResellerGuid",
                table: "ResellersStocks");

            migrationBuilder.RenameTable(
                name: "ResellersStocks",
                newName: "ResellersStock");

            migrationBuilder.RenameIndex(
                name: "IX_ResellersStocks_ResellerId",
                table: "ResellersStock",
                newName: "IX_ResellersStock_ResellerId");

            migrationBuilder.RenameIndex(
                name: "IX_ResellersStocks_ProductId",
                table: "ResellersStock",
                newName: "IX_ResellersStock_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResellersStock",
                table: "ResellersStock",
                column: "ResellerStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellersStock_Products_ProductId",
                table: "ResellersStock",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResellersStock_Resellers_ResellerId",
                table: "ResellersStock",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "ResellerId");
        }
    }
}
