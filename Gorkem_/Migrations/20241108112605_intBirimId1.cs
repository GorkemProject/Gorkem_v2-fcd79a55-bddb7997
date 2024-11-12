using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class intBirimId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "BirimTabloID",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.AlterColumn<int>(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirimTabloID",
                table: "UT_Kopek_Kopeks",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
