using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class createAdayIdareciTestiYapanSicil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_AdayIdareci_UT_KursEgitmenler_TestiYapanId",
                table: "UT_AdayIdareci");

            migrationBuilder.DropIndex(
                name: "IX_UT_AdayIdareci_TestiYapanId",
                table: "UT_AdayIdareci");

            migrationBuilder.RenameColumn(
                name: "TestiYapanId",
                table: "UT_AdayIdareci",
                newName: "TestiYapanSicil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestiYapanSicil",
                table: "UT_AdayIdareci",
                newName: "TestiYapanId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_TestiYapanId",
                table: "UT_AdayIdareci",
                column: "TestiYapanId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_AdayIdareci_UT_KursEgitmenler_TestiYapanId",
                table: "UT_AdayIdareci",
                column: "TestiYapanId",
                principalTable: "UT_KursEgitmenler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
