using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class addUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Responsaveis_UserID",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abfc8f67-2ea2-4855-8054-aafa16d19107", "AQAAAAIAAYagAAAAEPUEPxS5R14yhE7L76980QzJmO0PEr37VWS+nkpZyajeYTL88a2IJjlfcFBHll/0gA==", "242a0247-72a8-4a2a-8444-d0d7558c7c85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3d1572f-7ef2-48c7-bc33-4dd7dcab7d92", "AQAAAAIAAYagAAAAEIgOalFQ/rPNeKVqw1fAj+Ij+Lghv3wjWlnh4cgmjIVAb0ihW4UiqCOVoPCWk9uXzg==", "02c9b767-3bfc-4c3a-a6f6-73f29fa2e0ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb0fae52-35e8-4fc8-9ef2-00917354679b", "AQAAAAIAAYagAAAAEOlC2Qp75csFXe0Yo6IsACvcZRucotsR/esYi0sMLwvF2oE8RhSvLEfvHA2/wnnQ1w==", "c7dc2779-0762-4708-a699-986e0bfec8a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsaveis_UserID",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Pessoas");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d4dd2b-447d-431f-a5ca-c86d04cfb9b5", "AQAAAAIAAYagAAAAEJyURFQHHe4RWh8YYJwCi4C16a+vg0xg1DoCEA3nPWggKMCQiq9r2bmdSX+PY+zoPw==", "352f21cc-67a2-4890-8a88-673980205742" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "824b59f3-5082-40fa-b05b-c81ce69285b6", "AQAAAAIAAYagAAAAEPsOGr6OSwXjz8gXHp36Xbjl7YTH6VJFXS19Yzj8h+sVYNfG2/ToL5m0phPod8PsmA==", "acf4f645-5929-4ed9-a039-b7f8e224cd36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1475d596-8de2-48ee-b77f-22fdd6d64556", "AQAAAAIAAYagAAAAEMtc/dnj6rLgMQrRyCerBWMdL5tXImHI73Cn4rRAwbUErrkZPU7KH6AVaUoED9Oifg==", "484d6fcb-e260-46f0-9a2d-fe44327ba665" });
        }
    }
}
