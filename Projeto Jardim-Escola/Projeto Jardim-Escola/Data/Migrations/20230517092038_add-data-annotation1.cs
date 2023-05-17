using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddataannotation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "230ec767-75c6-46c5-b828-b98eba6545e3", "AQAAAAIAAYagAAAAEHp5vtidi2m41ADk6y1WqAfBuO6oG0HAVWh+0KXzCky5/rRcOP1flYvHQNfHwJYLiw==", "ebd1348f-3f56-4993-ae68-53a0ac5851d0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf0230b-daf8-41ce-93b5-0c03e6084ad3", "AQAAAAIAAYagAAAAEEQYb4uS68sFbH5ONZYsCz2IECRYZD7eOuBVXXwSVfu4wfUPLe/y11yCtvBYhPMyaw==", "bceb7217-a7ca-43cc-a26f-03ea78994e95" });
        }
    }
}
