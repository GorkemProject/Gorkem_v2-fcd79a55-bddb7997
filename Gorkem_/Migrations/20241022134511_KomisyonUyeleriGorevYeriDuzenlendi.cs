using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KomisyonUyeleriGorevYeriDuzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorevYeri",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.AddColumn<int>(
                name: "GorevYeriId",
                table: "UT_KomisyonUyeleris",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KomisyonUyeleris_GorevYeriId",
                table: "UT_KomisyonUyeleris",
                column: "GorevYeriId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KomisyonUyeleris_KT_GorevYeris_GorevYeriId",
                table: "UT_KomisyonUyeleris",
                column: "GorevYeriId",
                principalTable: "KT_GorevYeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KomisyonUyeleris_KT_GorevYeris_GorevYeriId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropIndex(
                name: "IX_UT_KomisyonUyeleris_GorevYeriId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.DropColumn(
                name: "GorevYeriId",
                table: "UT_KomisyonUyeleris");

            migrationBuilder.AddColumn<string>(
                name: "GorevYeri",
                table: "UT_KomisyonUyeleris",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
