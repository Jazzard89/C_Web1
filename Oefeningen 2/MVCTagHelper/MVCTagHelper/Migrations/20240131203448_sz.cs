using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTagHelper.Migrations
{
    public partial class sz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerker",
                columns: table => new
                {
                    MedewerkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voornaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.MedewerkerId);
                    table.ForeignKey(
                        name: "FK_Medewerker_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdeling",
                        principalColumn: "AfdelingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_AfdelingId",
                table: "Medewerker",
                column: "AfdelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medewerker");
        }
    }
}
