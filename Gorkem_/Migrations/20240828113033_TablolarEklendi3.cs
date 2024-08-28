using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class TablolarEklendi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktifmi",
                table: "UT_Kopek_Kopeks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "T_Aktif",
                table: "UT_Kopek_Kopeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "T_Pasif",
                table: "UT_Kopek_Kopeks",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktifmi",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "T_Aktif",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "T_Pasif",
                table: "UT_Kopek_Kopeks");
        }
    }
}
