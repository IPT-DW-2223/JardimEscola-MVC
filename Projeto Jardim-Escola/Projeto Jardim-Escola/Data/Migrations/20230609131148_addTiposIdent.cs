using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTiposIdent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "TiposIdentificacao",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Cartão de Cidadão" },
                    { 2, "Bilhete de Identidade" },
                    { 3, "Passaporte" },
                    { 4, "Título de Residência" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposIdentificacao",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposIdentificacao",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposIdentificacao",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposIdentificacao",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2293d6f5-d30f-45cf-b2ef-aec38a8c602a", "AQAAAAIAAYagAAAAEGD9Ei+C5TG5xS2439unFTPc+tGovB8Abcou574o6zcQrz6HaauZdUUuyY7EhF68aA==", "d4a37e6b-483c-4c2f-ac23-f1feb1426524" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1589eca7-df2e-41c3-8a5c-9f1d2fb2f14f", "AQAAAAIAAYagAAAAEIjyZb8K/o80nXwJxDe+HQ6TVSLt2e2TQxbIP6z1hMCVAYJgCgp5t/HYy5tfdpY+Ig==", "1a205ed9-5d5a-4bfb-84a9-d8b8f6196528" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42c79483-6594-4dfd-8a57-e6845f1f7e05", "AQAAAAIAAYagAAAAEM0QH0w01WFBmGWJKfIsLjFNl4Y9PEzhPI9kXWxSgde4NuryMiz0WFswKWX+WSe+jQ==", "dcd9b617-bf74-4214-a61d-ab193ea91ccb" });
        }
    }
}
