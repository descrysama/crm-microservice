using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace userMicroService.Migrations
{
    /// <inheritdoc />
    public partial class initDatase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "visiteur" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
