using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.API.Migrations;

/// <inheritdoc />
public partial class _20261117142649_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "UrlMappings",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ShortCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                OriginalUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UrlMappings", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_UrlMappings_ShortCode",
            table: "UrlMappings",
            column: "ShortCode",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "UrlMappings");
    }
}
