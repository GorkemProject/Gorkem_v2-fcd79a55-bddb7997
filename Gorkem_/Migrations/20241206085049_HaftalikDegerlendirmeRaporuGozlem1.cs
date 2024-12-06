using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class HaftalikDegerlendirmeRaporuGozlem1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporu_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.DropIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropColumn(
                name: "HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporu",
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
                    table.PrimaryKey("PK_UT_KursHaftalıkDegerlendirmeRaporu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursHaftalıkDegerlendirmeRaporu_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursHaftalıkDegerlendirmeRaporu_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporu",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporu_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId",
                principalTable: "UT_KursHaftalıkDegerlendirmeRaporu",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
