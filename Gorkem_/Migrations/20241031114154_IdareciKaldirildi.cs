using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciKaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_SecimTests_UT_Idarecis_IdareciId",
                table: "UT_SecimTests");

            migrationBuilder.DropIndex(
                name: "IX_UT_SecimTests_IdareciId",
                table: "UT_SecimTests");

            migrationBuilder.DropColumn(
                name: "IdareciId",
                table: "UT_SecimTests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdareciId",
                table: "UT_SecimTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_IdareciId",
                table: "UT_SecimTests",
                column: "IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_SecimTests_UT_Idarecis_IdareciId",
                table: "UT_SecimTests",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
