using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class UtilizadorCargos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f0917f5-e608-498d-aa89-31f9c94a69ac", "ADMIN@JARDIMESCOLA.COM", "AQAAAAIAAYagAAAAEEguNXzt6+MmIC9wjmPB16yk2ltyR4DGeME2QBC5SZ6ZmX+NixrKVg8PePzvSJB4cg==", "d8ed650a-2e3a-4636-b7a9-ca8bc33b42dd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d50487e-fd30-4830-aca2-884e01cc6a8e", "ADMIN@JARDIMESCOL.COM", "AQAAAAIAAYagAAAAEII6Z634o9XEb/VdpikGwp2+GpsS4dKvjUEcRgzyXA1eFKuMZCtQhxsdwww4MC8gSg==", "605fa366-d33d-4175-8573-07756d512e0a" });
        }
    }
}
