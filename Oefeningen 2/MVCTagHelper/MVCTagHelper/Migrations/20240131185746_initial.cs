using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTagHelper.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    LandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land", x => x.LandId);
                });

            migrationBuilder.CreateTable(
                name: "Locatie",
                columns: table => new
                {
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatie", x => x.LocatieId);
                    table.ForeignKey(
                        name: "FK_Locatie_Land_LandId",
                        column: x => x.LandId,
                        principalTable: "Land",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afdeling",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.AfdelingId);
                    table.ForeignKey(
                        name: "FK_Afdeling_Locatie_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locatie",
                        principalColumn: "LocatieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afdeling_LocatieId",
                table: "Afdeling",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Locatie_LandId",
                table: "Locatie",
                column: "LandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afdeling");

            migrationBuilder.DropTable(
                name: "Locatie");

            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
