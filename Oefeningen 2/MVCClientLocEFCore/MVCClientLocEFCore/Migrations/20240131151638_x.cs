using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCClientLocEFCore.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_ClientId",
                table: "Location",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Client_ClientId",
                table: "Location",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Client_ClientId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_ClientId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Location");
        }
    }
}
