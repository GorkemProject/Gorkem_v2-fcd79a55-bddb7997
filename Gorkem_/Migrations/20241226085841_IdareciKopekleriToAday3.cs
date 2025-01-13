using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciKopekleriToAday3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_UT_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropIndex(
                name: "IX_UT_IdareciKopekleri_UT_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropColumn(
                name: "UT_IdareciId",
                table: "UT_IdareciKopekleri");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UT_IdareciId",
                table: "UT_IdareciKopekleri",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_IdareciKopekleri_UT_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "UT_IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_UT_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "UT_IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }
    }
}
