using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class CalKadAddBirim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.AlterColumn<int>(
                name: "IdareciId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AtamaTuru",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekCalKads_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_Birims_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_Birims_BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropIndex(
                name: "IX_UT_KopekCalKads_BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.AlterColumn<int>(
                name: "IdareciId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtamaTuru",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
