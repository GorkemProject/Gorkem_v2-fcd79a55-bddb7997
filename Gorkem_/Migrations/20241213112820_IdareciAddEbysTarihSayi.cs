using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciAddEbysTarihSayi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EbysEvrakSayisi",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EbysEvrakTarihi",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EbysEvrakSayisi",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "EbysEvrakTarihi",
                table: "UT_Idarecis");
        }
    }
}
