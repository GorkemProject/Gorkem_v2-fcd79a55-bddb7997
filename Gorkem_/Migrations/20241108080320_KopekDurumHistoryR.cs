using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekDurumHistoryR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_KopekDurumHistory_UT_Kopek_Kopeks_KopekId",
                table: "KT_KopekDurumHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_KopekDurumHistory",
                table: "KT_KopekDurumHistory");

            migrationBuilder.RenameTable(
                name: "KT_KopekDurumHistory",
                newName: "UT_KopekDurumHistory");

            migrationBuilder.RenameIndex(
                name: "IX_KT_KopekDurumHistory_KopekId",
                table: "UT_KopekDurumHistory",
                newName: "IX_UT_KopekDurumHistory_KopekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_KopekDurumHistory",
                table: "UT_KopekDurumHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekDurumHistory_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekDurumHistory",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekDurumHistory_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekDurumHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_KopekDurumHistory",
                table: "UT_KopekDurumHistory");

            migrationBuilder.RenameTable(
                name: "UT_KopekDurumHistory",
                newName: "KT_KopekDurumHistory");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KopekDurumHistory_KopekId",
                table: "KT_KopekDurumHistory",
                newName: "IX_KT_KopekDurumHistory_KopekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_KopekDurumHistory",
                table: "KT_KopekDurumHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_KopekDurumHistory_UT_Kopek_Kopeks_KopekId",
                table: "KT_KopekDurumHistory",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
