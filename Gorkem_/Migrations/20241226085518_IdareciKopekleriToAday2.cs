using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciKopekleriToAday2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_AdayIdareci_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.RenameColumn(
                name: "IdareciId",
                table: "UT_KopekCalKads",
                newName: "AdayIdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KopekCalKads_IdareciId",
                table: "UT_KopekCalKads",
                newName: "IX_UT_KopekCalKads_AdayIdareciId");

            migrationBuilder.RenameColumn(
                name: "IdareciId",
                table: "UT_IdareciKopekleri",
                newName: "AdayIdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_IdareciKopekleri_IdareciId",
                table: "UT_IdareciKopekleri",
                newName: "IX_UT_IdareciKopekleri_AdayIdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_AdayIdareci_AdayIdareciId",
                table: "UT_IdareciKopekleri",
                column: "AdayIdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_AdayIdareci_AdayIdareciId",
                table: "UT_KopekCalKads",
                column: "AdayIdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_AdayIdareci_AdayIdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_AdayIdareci_AdayIdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.RenameColumn(
                name: "AdayIdareciId",
                table: "UT_KopekCalKads",
                newName: "IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KopekCalKads_AdayIdareciId",
                table: "UT_KopekCalKads",
                newName: "IX_UT_KopekCalKads_IdareciId");

            migrationBuilder.RenameColumn(
                name: "AdayIdareciId",
                table: "UT_IdareciKopekleri",
                newName: "IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_IdareciKopekleri_AdayIdareciId",
                table: "UT_IdareciKopekleri",
                newName: "IX_UT_IdareciKopekleri_IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_AdayIdareci_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "IdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }
    }
}
