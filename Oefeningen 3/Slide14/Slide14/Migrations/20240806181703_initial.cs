using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slide14.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "landen",
                columns: table => new
                {
                    LandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandNaam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_landen", x => x.LandId);
                });

            migrationBuilder.CreateTable(
                name: "locaties",
                columns: table => new
                {
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locaties", x => x.LocatieId);
                    table.ForeignKey(
                        name: "FK_locaties_landen_LandId",
                        column: x => x.LandId,
                        principalTable: "landen",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "afdelingen",
                columns: table => new
                {
                    AfdelingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfdelingNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_afdelingen", x => x.AfdelingId);
                    table.ForeignKey(
                        name: "FK_afdelingen_locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "locaties",
                        principalColumn: "LocatieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_afdelingen_LocatieId",
                table: "afdelingen",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_locaties_LandId",
                table: "locaties",
                column: "LandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "afdelingen");

            migrationBuilder.DropTable(
                name: "locaties");

            migrationBuilder.DropTable(
                name: "landen");
        }
    }
}
