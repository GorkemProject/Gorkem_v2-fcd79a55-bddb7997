using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class longBirimId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId1",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId1",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "FiiliBirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "BirimId1",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BirimTabloID",
                table: "UT_Kopek_Kopeks",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "BirimTabloID",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AddColumn<int>(
                name: "FiiliBirimId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BirimId1",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId1",
                table: "UT_Kopek_Kopeks",
                column: "BirimId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId1",
                table: "UT_Kopek_Kopeks",
                column: "BirimId1",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
