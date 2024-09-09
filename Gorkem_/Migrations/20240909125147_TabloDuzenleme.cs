using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class TabloDuzenleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KopekAdi",
                table: "UT_Kopek_Kopeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KopekAdi",
                table: "UT_Kopek_Kopeks");
        }
    }
}
