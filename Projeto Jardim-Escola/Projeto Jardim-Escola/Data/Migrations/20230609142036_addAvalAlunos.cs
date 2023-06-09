using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class addAvalAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avaliacao",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f78d33ce-091d-4a61-b80e-ce5092a9f073", "AQAAAAIAAYagAAAAEM+ItjmXEX91cu7fl7psjihkeH/0HeTm6FOhwE8QR+wbNoEAqWEf0DR0AsJkOLRH5Q==", "4b3d6a49-f546-456f-9537-3e9745ddf94d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4651e33-98e9-4759-9245-e87d07ad01cd", "AQAAAAIAAYagAAAAEFsrABGysiSer+U5kS3wD5ik48O3Ec5bNn/z0pMhNaDftnTN55Ow6uL1Iag1VwTCPg==", "0187b3f9-9f3c-4a09-bb06-3d10901e2c50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f8b6bee-b326-44f6-af4f-a152bd746909", "AQAAAAIAAYagAAAAELmqESLGlGI/gtw81kkwCMs7+TuDW8negjbD97lA718iensdJXXvpv0JZ7Dr3MrEVA==", "920d1c74-1592-4176-81d3-343e63038e03" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avaliacao",
                table: "Pessoas");

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
    }
}
