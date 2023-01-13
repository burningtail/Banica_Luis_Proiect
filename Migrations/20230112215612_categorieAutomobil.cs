using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banica_Luis_Proiect.Migrations
{
    public partial class categorieAutomobil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorieAutomobil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutomobilId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAutomobil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategorieAutomobil_Automobil_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieAutomobil_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAutomobil_AutomobilId",
                table: "CategorieAutomobil",
                column: "AutomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieAutomobil_CategorieId",
                table: "CategorieAutomobil",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieAutomobil");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
