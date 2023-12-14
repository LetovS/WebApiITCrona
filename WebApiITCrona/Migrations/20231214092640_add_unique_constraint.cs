using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiITCrona.Migrations
{
    public partial class add_unique_constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "Calls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "UQ_Calls_IpAddress",
                table: "Calls",
                column: "IpAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Calls_IpAddress",
                table: "Calls");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
