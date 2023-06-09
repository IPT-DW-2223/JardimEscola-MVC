using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
