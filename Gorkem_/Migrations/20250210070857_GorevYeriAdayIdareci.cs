using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class GorevYeriAdayIdareci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_AdayIdareci_KT_KadroIls_KadroIlId",
                table: "UT_AdayIdareci");

            migrationBuilder.RenameColumn(
                name: "KadroIlId",
                table: "UT_AdayIdareci",
                newName: "GorevYeriId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_AdayIdareci_KadroIlId",
                table: "UT_AdayIdareci",
                newName: "IX_UT_AdayIdareci_GorevYeriId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_AdayIdareci_KT_GorevYeris_GorevYeriId",
                table: "UT_AdayIdareci",
                column: "GorevYeriId",
                principalTable: "KT_GorevYeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_AdayIdareci_KT_GorevYeris_GorevYeriId",
                table: "UT_AdayIdareci");

            migrationBuilder.RenameColumn(
                name: "GorevYeriId",
                table: "UT_AdayIdareci",
                newName: "KadroIlId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_AdayIdareci_GorevYeriId",
                table: "UT_AdayIdareci",
                newName: "IX_UT_AdayIdareci_KadroIlId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_AdayIdareci_KT_KadroIls_KadroIlId",
                table: "UT_AdayIdareci",
                column: "KadroIlId",
                principalTable: "KT_KadroIls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
