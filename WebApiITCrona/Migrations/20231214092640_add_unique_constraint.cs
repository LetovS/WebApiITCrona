using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiITCrona.Migrations;

/// <summary>
/// Добавлен констрэйнт на свойство IP адреса
/// </summary>
public partial class Add_unique_constraint : Migration
{
    /// <inheritdoc/>
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

    /// <inheritdoc/>
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
