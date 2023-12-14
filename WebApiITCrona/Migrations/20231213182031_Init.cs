using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiITCrona.Migrations;

/// <summary>
/// Инициализирующая миграция
/// </summary>
public partial class Init : Migration
{
    /// <inheritdoc/>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Calls",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Calls", x => x.Id);
            });
    }

    /// <inheritdoc/>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Calls");
    }
}
