using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KiwiLoad.Infrastructure.SqlServerDesign.Migrations;

/// <inheritdoc />
public partial class Start : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "Kl");

        migrationBuilder.CreateTable(
            name: "Users",
            schema: "Kl",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                AddUserId = table.Column<int>(type: "int", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdateUserId = table.Column<int>(type: "int", nullable: false),
                DisableDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                DisableUserId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Warehouses",
            schema: "Kl",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                AddUserId = table.Column<int>(type: "int", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdateUserId = table.Column<int>(type: "int", nullable: false),
                DisableDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                DisableUserId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Warehouses", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Users",
            schema: "Kl");

        migrationBuilder.DropTable(
            name: "Warehouses",
            schema: "Kl");
    }
}
