using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class DarCargoAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "adm", "0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdbccf59-307c-4a2d-8ba9-956c468bb0b6", "AQAAAAIAAYagAAAAEFs/XS5Z+WeG/xBe5dlQfp7VVaRc30zy0VUiJCz6qMv7sXZeNVtpMNcgQz2ZxanQzQ==", "775c5ba3-6dab-47e9-83ae-efb2bdb13071" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adm", "0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f0917f5-e608-498d-aa89-31f9c94a69ac", "AQAAAAIAAYagAAAAEEguNXzt6+MmIC9wjmPB16yk2ltyR4DGeME2QBC5SZ6ZmX+NixrKVg8PePzvSJB4cg==", "d8ed650a-2e3a-4636-b7a9-ca8bc33b42dd" });
        }
    }
}
