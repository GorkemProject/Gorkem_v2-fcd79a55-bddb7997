using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class calKadExitIlkSonID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlkId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "OncekiId",
                table: "UT_KopekCalKads");

            migrationBuilder.AlterColumn<string>(
                name: "AtamaEvrakSayısı",
                table: "UT_KopekCalKads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AtamaEvrakSayısı",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IlkId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OncekiId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
