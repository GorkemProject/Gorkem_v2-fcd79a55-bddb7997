using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class SecimTesteKomisyonEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestKomisyonu",
                table: "UT_SecimTests");

            migrationBuilder.AddColumn<int>(
                name: "KomisyonId",
                table: "UT_SecimTests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_KomisyonId",
                table: "UT_SecimTests",
                column: "KomisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_SecimTests_UT_Komisyons_KomisyonId",
                table: "UT_SecimTests",
                column: "KomisyonId",
                principalTable: "UT_Komisyons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_SecimTests_UT_Komisyons_KomisyonId",
                table: "UT_SecimTests");

            migrationBuilder.DropIndex(
                name: "IX_UT_SecimTests_KomisyonId",
                table: "UT_SecimTests");

            migrationBuilder.DropColumn(
                name: "KomisyonId",
                table: "UT_SecimTests");

            migrationBuilder.AddColumn<string>(
                name: "TestKomisyonu",
                table: "UT_SecimTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
