using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddContas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d4dd2b-447d-431f-a5ca-c86d04cfb9b5", "AQAAAAIAAYagAAAAEJyURFQHHe4RWh8YYJwCi4C16a+vg0xg1DoCEA3nPWggKMCQiq9r2bmdSX+PY+zoPw==", "352f21cc-67a2-4890-8a88-673980205742" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "824b59f3-5082-40fa-b05b-c81ce69285b6", "resp@jardimescola.com", true, false, null, "RESP@JARDIMESCOLA.COM", "RESP@JARDIMESCOLA.COM", "AQAAAAIAAYagAAAAEPsOGr6OSwXjz8gXHp36Xbjl7YTH6VJFXS19Yzj8h+sVYNfG2/ToL5m0phPod8PsmA==", null, false, "acf4f645-5929-4ed9-a039-b7f8e224cd36", false, "resp@jardimescola.com" },
                    { "2", 0, "1475d596-8de2-48ee-b77f-22fdd6d64556", "prof@jardimescola.com", true, false, null, "PROF@JARDIMESCOLA.COM", "PROF@JARDIMESCOLA.COM", "AQAAAAIAAYagAAAAEMtc/dnj6rLgMQrRyCerBWMdL5tXImHI73Cn4rRAwbUErrkZPU7KH6AVaUoED9Oifg==", null, false, "484d6fcb-e260-46f0-9a2d-fe44327ba665", false, "prof@jardimescola.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "enc", "1" },
                    { "prof", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee18ea32-b342-4f1e-a874-24ed50a5407b", "AQAAAAIAAYagAAAAEDf6B49x8LrmHswkGq+VyagqPnvO7utCtVIy7JvsLDDfJaM8KY6smIS5QJJEFXpG3A==", "aa0727c6-0a1c-4642-b7d9-8219336c1f9d" });
        }
    }
}
