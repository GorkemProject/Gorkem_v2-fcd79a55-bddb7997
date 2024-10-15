using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KomisyonHavuzEklendi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KomisyonId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropColumn(
                name: "KomisyonUyeleriId",
                table: "UT_Komisyons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KomisyonId",
                table: "UT_KomisyonUyeleris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KomisyonUyeleriId",
                table: "UT_Komisyons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
