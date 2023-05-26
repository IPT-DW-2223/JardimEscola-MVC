using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAtivoToAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pessoas",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee18ea32-b342-4f1e-a874-24ed50a5407b", "AQAAAAIAAYagAAAAEDf6B49x8LrmHswkGq+VyagqPnvO7utCtVIy7JvsLDDfJaM8KY6smIS5QJJEFXpG3A==", "aa0727c6-0a1c-4642-b7d9-8219336c1f9d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pessoas");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "230ec767-75c6-46c5-b828-b98eba6545e3", "AQAAAAIAAYagAAAAEHp5vtidi2m41ADk6y1WqAfBuO6oG0HAVWh+0KXzCky5/rRcOP1flYvHQNfHwJYLiw==", "ebd1348f-3f56-4993-ae68-53a0ac5851d0" });
        }
    }
}
