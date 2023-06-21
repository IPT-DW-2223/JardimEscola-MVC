using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracaoFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosTurmas");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "enc", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "prof", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.RenameColumn(
                name: "Responsaveis_UserID",
                table: "Pessoas",
                newName: "Responsavel_UserID");

            migrationBuilder.RenameColumn(
                name: "Responsaveis_Telemovel",
                table: "Pessoas",
                newName: "Responsavel_Telemovel");

            migrationBuilder.RenameColumn(
                name: "Responsaveis_Email",
                table: "Pessoas",
                newName: "Responsavel_Email");

            migrationBuilder.RenameColumn(
                name: "AnoLetivo",
                table: "AnosLetivos",
                newName: "NomeAnoLetivo");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel_Email",
                table: "Pessoas",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTurma", x => new { x.AlunosId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Pessoas_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTurma_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "805ffdd9-df1e-4c48-8699-e1dc4a1dad82", "AQAAAAIAAYagAAAAEGr02grSJDsrthGGjFuQlKoqNitxt3qZkwP35tF2dmeU9hfLT7AGkE7WjbB1vd8V+A==", "4d251605-a817-4d22-9fae-74e0fef92075" });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_TurmasId",
                table: "AlunoTurma",
                column: "TurmasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.RenameColumn(
                name: "Responsavel_UserID",
                table: "Pessoas",
                newName: "Responsaveis_UserID");

            migrationBuilder.RenameColumn(
                name: "Responsavel_Telemovel",
                table: "Pessoas",
                newName: "Responsaveis_Telemovel");

            migrationBuilder.RenameColumn(
                name: "Responsavel_Email",
                table: "Pessoas",
                newName: "Responsaveis_Email");

            migrationBuilder.RenameColumn(
                name: "NomeAnoLetivo",
                table: "AnosLetivos",
                newName: "AnoLetivo");

            migrationBuilder.AlterColumn<string>(
                name: "Responsaveis_Email",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AlunosTurmas",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosTurmas", x => new { x.AlunosId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Pessoas_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosTurmas_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78d33ce-091d-4a61-b80e-ce5092a9f073", "AQAAAAIAAYagAAAAEM+ItjmXEX91cu7fl7psjihkeH/0HeTm6FOhwE8QR+wbNoEAqWEf0DR0AsJkOLRH5Q==", "4b3d6a49-f546-456f-9537-3e9745ddf94d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "c4651e33-98e9-4759-9245-e87d07ad01cd", "resp@jardimescola.com", true, false, null, "RESP@JARDIMESCOLA.COM", "RESP@JARDIMESCOLA.COM", "AQAAAAIAAYagAAAAEFsrABGysiSer+U5kS3wD5ik48O3Ec5bNn/z0pMhNaDftnTN55Ow6uL1Iag1VwTCPg==", null, false, "0187b3f9-9f3c-4a09-bb06-3d10901e2c50", false, "resp@jardimescola.com" },
                    { "2", 0, "5f8b6bee-b326-44f6-af4f-a152bd746909", "prof@jardimescola.com", true, false, null, "PROF@JARDIMESCOLA.COM", "PROF@JARDIMESCOLA.COM", "AQAAAAIAAYagAAAAELmqESLGlGI/gtw81kkwCMs7+TuDW8negjbD97lA718iensdJXXvpv0JZ7Dr3MrEVA==", null, false, "920d1c74-1592-4176-81d3-343e63038e03", false, "prof@jardimescola.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "enc", "1" },
                    { "prof", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosTurmas_TurmasId",
                table: "AlunosTurmas",
                column: "TurmasId");
        }
    }
}
