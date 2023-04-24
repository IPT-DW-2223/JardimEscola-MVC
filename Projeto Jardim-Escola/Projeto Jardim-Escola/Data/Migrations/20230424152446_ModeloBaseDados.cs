using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeloBaseDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Morada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificacaoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escolariedade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncEducacaoFK = table.Column<int>(type: "int", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Pessoas_EncEducacaoFK",
                        column: x => x.EncEducacaoFK,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoLetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Pessoas_ProfessorFK",
                        column: x => x.ProfessorFK,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EncEducacaoFK",
                table: "Pessoas",
                column: "EncEducacaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TurmasId",
                table: "Pessoas",
                column: "TurmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ProfessorFK",
                table: "Turmas",
                column: "ProfessorFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Turmas_TurmasId",
                table: "Pessoas",
                column: "TurmasId",
                principalTable: "Turmas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Turmas_TurmasId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
