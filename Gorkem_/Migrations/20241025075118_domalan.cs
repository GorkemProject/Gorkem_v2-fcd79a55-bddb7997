using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class domalan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_Sorus_KT_SecimTests_KT_SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.DropIndex(
                name: "IX_KT_Sorus_KT_SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.DropColumn(
                name: "KT_SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.AddColumn<int>(
                name: "SecimTestId",
                table: "KT_Sorus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_KT_Sorus_SecimTestId",
                table: "KT_Sorus",
                column: "SecimTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_Sorus_KT_SecimTests_SecimTestId",
                table: "KT_Sorus",
                column: "SecimTestId",
                principalTable: "KT_SecimTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_Sorus_KT_SecimTests_SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.DropIndex(
                name: "IX_KT_Sorus_SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.DropColumn(
                name: "SecimTestId",
                table: "KT_Sorus");

            migrationBuilder.AddColumn<int>(
                name: "KT_SecimTestId",
                table: "KT_Sorus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KT_Sorus_KT_SecimTestId",
                table: "KT_Sorus",
                column: "KT_SecimTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_Sorus_KT_SecimTests_KT_SecimTestId",
                table: "KT_Sorus",
                column: "KT_SecimTestId",
                principalTable: "KT_SecimTests",
                principalColumn: "Id");
        }
    }
}
