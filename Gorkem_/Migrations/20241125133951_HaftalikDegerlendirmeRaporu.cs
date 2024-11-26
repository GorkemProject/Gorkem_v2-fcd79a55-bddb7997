using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class HaftalikDegerlendirmeRaporu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursHaftalıkDegerlendirmeRaporus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursHaftalıkDegerlendirmeRaporus_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursiyerId = table.Column<int>(type: "int", nullable: false),
                    Gozlemler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UT_KursHaftalıkDegerlendirmeRaporuId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_HaftalıkDegerlendirmeRaporuGozlemlers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_UT_KursHaftalıkDegerlendirmeRaporuId",
                        column: x => x.UT_KursHaftalıkDegerlendirmeRaporuId,
                        principalTable: "UT_KursHaftalıkDegerlendirmeRaporus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_Kursiyer_KursiyerId",
                        column: x => x.KursiyerId,
                        principalTable: "UT_Kursiyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_KursiyerId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "KursiyerId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "UT_KursHaftalıkDegerlendirmeRaporuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursHaftalıkDegerlendirmeRaporus_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporus",
                column: "KursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporus");
        }
    }
}
