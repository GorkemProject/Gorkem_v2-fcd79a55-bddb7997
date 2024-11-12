using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekDurumHistoryUt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_FiiliBirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropTable(
                name: "KT_FiiliBirims");

            migrationBuilder.DropIndex(
                name: "IX_UT_KopekCalKads_FiiliBirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "KT_KopekDurumHistory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "KT_KopekDurumHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "KT_FiiliBirims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_FiiliBirims", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekCalKads_FiiliBirimId",
                table: "UT_KopekCalKads",
                column: "FiiliBirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_FiiliBirimId",
                table: "UT_KopekCalKads",
                column: "FiiliBirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
