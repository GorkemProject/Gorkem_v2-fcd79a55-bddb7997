using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addBirimTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktifmi",
                table: "KT_Birims");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KT_Birims");

            migrationBuilder.DropColumn(
                name: "T_Aktif",
                table: "KT_Birims");

            migrationBuilder.DropColumn(
                name: "T_Pasif",
                table: "KT_Birims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktifmi",
                table: "KT_Birims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KT_Birims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "T_Aktif",
                table: "KT_Birims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "T_Pasif",
                table: "KT_Birims",
                type: "datetime2",
                nullable: true);
        }
    }
}
