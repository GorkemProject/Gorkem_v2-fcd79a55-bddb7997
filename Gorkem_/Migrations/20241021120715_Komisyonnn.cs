using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class Komisyonnn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorevYeri",
                table: "UT_Komisyons");

            migrationBuilder.AddColumn<int>(
                name: "GorevYeriId",
                table: "UT_Komisyons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KT_GorevYeris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_GorevYeris", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Komisyons_GorevYeriId",
                table: "UT_Komisyons",
                column: "GorevYeriId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Komisyons_KT_GorevYeris_GorevYeriId",
                table: "UT_Komisyons",
                column: "GorevYeriId",
                principalTable: "KT_GorevYeris",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Komisyons_KT_GorevYeris_GorevYeriId",
                table: "UT_Komisyons");

            migrationBuilder.DropTable(
                name: "KT_GorevYeris");

            migrationBuilder.DropIndex(
                name: "IX_UT_Komisyons_GorevYeriId",
                table: "UT_Komisyons");

            migrationBuilder.DropColumn(
                name: "GorevYeriId",
                table: "UT_Komisyons");

            migrationBuilder.AddColumn<string>(
                name: "GorevYeri",
                table: "UT_Komisyons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
