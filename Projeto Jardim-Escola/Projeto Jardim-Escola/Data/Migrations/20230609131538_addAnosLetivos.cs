using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAnosLetivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnosLetivos",
                columns: new[] { "Id", "AnoLetivo" },
                values: new object[,]
                {
                    { 1, "2021-2022" },
                    { 2, "2022-2023" },
                    { 3, "2023-2024" },
                    { 4, "2024-2025" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab01f9ce-d7f7-478d-9215-2c4633d6966a", "AQAAAAIAAYagAAAAEFCbOd92fHHLwP2aH/Iz62TBGnPW17LiAQmmW5EBCTfXNy/uDxzmFv2C4lP63dsanA==", "cbff03f7-97ea-454f-adad-625e2f32b525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e02ca9e7-bd69-416b-8731-748a49b89bdf", "AQAAAAIAAYagAAAAEK8oKi3qqneF6ebh4BDXVy5O2kGHpBTbUnMN/ck92BmWGaJp+16I9l93IYBW5fknGw==", "fac12aba-8ad9-404c-bb9e-b0cf85a953d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29841504-4ddf-4bc8-b2b3-ff390144ab07", "AQAAAAIAAYagAAAAEOo9h84Vjyb/qnSn/EAtS2/AnHd0iXxmYcai/nyzoDdjq4R5c5huw3NuJopa5o1Tog==", "7401229d-a506-4eda-a55e-ae38f4ac3b2f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnosLetivos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnosLetivos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnosLetivos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnosLetivos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cf88e0d-a809-465b-a845-cd1a390bc970", "AQAAAAIAAYagAAAAENwdgxUyGaiYnB1I6ZLZgXud3akAJVHa2UXVJ/Z/O4PZwM9agCfSXpVJpXesdZSxCQ==", "fa40fa6a-848b-4bbd-869a-a7cc1167c4c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63fef22c-bc7d-408e-adf9-1adaa53070d0", "AQAAAAIAAYagAAAAEI/PyLwKKWF9ma83PkZ0wqPCOdFLh8mNTcnuiFwQEQZB5fdIBTMmlYz8ejlhwoo5Jw==", "847c4e24-18c3-4c31-b6b2-83ed25c91178" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0914174a-2ae9-4d8c-8ea9-0cb4f314450f", "AQAAAAIAAYagAAAAEHEC83uYgkVzM46qu6s/havPBb+FhE9YtNYbbW/Mq3wLPnbnvaCCM1gxYSnD2IUR9A==", "cf6a4239-cba8-4f7a-817d-94a44d644c36" });
        }
    }
}
