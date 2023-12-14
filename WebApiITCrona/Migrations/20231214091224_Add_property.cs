using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiITCrona.Migrations;

/// <summary>
/// Добавлено свойство IP адреса
/// </summary>
public partial class Add_property : Migration
{
    /// <inheritdoc/>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "IpAddress",
            table: "Calls",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");
    }

    /// <inheritdoc/>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IpAddress",
            table: "Calls");
    }
}
