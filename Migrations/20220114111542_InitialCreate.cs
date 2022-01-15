using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nudge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    LienPhoto = table.Column<string>(type: "TEXT", nullable: true),
                    AdresseMail = table.Column<string>(type: "TEXT", nullable: true),
                    NumTel = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonneId = table.Column<int>(type: "INTEGER", nullable: false),
                    Intitule = table.Column<string>(type: "TEXT", nullable: true),
                    Commentaire = table.Column<string>(type: "TEXT", nullable: true),
                    Theme = table.Column<string>(type: "TEXT", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Progression = table.Column<int>(type: "INTEGER", nullable: false),
                    Reussite = table.Column<bool>(type: "INTEGER", nullable: false),
                    TousLesJours = table.Column<bool>(type: "INTEGER", nullable: false),
                    Repetition = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defi_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trophee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonneId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefiId = table.Column<int>(type: "INTEGER", nullable: false),
                    NomTrophee = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trophee_Defi_DefiId",
                        column: x => x.DefiId,
                        principalTable: "Defi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trophee_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defi_PersonneId",
                table: "Defi",
                column: "PersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophee_DefiId",
                table: "Trophee",
                column: "DefiId");

            migrationBuilder.CreateIndex(
                name: "IX_Trophee_PersonneId",
                table: "Trophee",
                column: "PersonneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trophee");

            migrationBuilder.DropTable(
                name: "Defi");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
