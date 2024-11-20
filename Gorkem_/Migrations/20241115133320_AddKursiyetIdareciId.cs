using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class AddKursiyetIdareciId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer");

            migrationBuilder.AlterColumn<int>(
                name: "IdareciId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer");

            migrationBuilder.AlterColumn<int>(
                name: "IdareciId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }
    }
}
