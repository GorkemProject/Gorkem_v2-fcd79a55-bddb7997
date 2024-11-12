using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFiiliBirims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_Birims_BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Birims",
                table: "KT_Birims");

            migrationBuilder.RenameTable(
                name: "KT_Birims",
                newName: "KT_FiiliBirims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_FiiliBirims",
                table: "KT_FiiliBirims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_FiiliBirims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_FiiliBirims_FiiliBirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_FiiliBirims",
                table: "KT_FiiliBirims");

            migrationBuilder.RenameTable(
                name: "KT_FiiliBirims",
                newName: "KT_Birims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Birims",
                table: "KT_Birims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_FiiliBirimId",
                table: "UT_Kopek_Kopeks",
                column: "FiiliBirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_Birims_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
