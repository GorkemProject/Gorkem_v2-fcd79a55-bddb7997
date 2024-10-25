using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class UT_SecimTestEklendi_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_SecimTestiCevaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtSecimTestId = table.Column<int>(type: "int", nullable: false),
                    SoruId = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_SecimTestiCevaplar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_SecimTestiCevaplar_KT_Sorus_SoruId",
                        column: x => x.SoruId,
                        principalTable: "KT_Sorus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_SecimTestiCevaplar_UT_SecimTests_UtSecimTestId",
                        column: x => x.UtSecimTestId,
                        principalTable: "UT_SecimTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTestiCevaplar_SoruId",
                table: "UT_SecimTestiCevaplar",
                column: "SoruId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTestiCevaplar_UtSecimTestId",
                table: "UT_SecimTestiCevaplar",
                column: "UtSecimTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_SecimTestiCevaplar");
        }
    }
}
