using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class GorevYeri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KadroIls_KadroIlId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.RenameColumn(
                name: "KadroIlId",
                table: "UT_Kopek_Kopeks",
                newName: "GorevYeriId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_KadroIlId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_GorevYeriId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_GorevYeris_GorevYeriId",
                table: "UT_Kopek_Kopeks",
                column: "GorevYeriId",
                principalTable: "KT_GorevYeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_GorevYeris_GorevYeriId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.RenameColumn(
                name: "GorevYeriId",
                table: "UT_Kopek_Kopeks",
                newName: "KadroIlId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_GorevYeriId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_KadroIlId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KadroIls_KadroIlId",
                table: "UT_Kopek_Kopeks",
                column: "KadroIlId",
                principalTable: "KT_KadroIls",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
