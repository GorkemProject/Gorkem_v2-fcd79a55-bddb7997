using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class HaftalikDegerlendirmeRaporu1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropColumn(
                name: "UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.CreateTable(
                name: "UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu",
                columns: table => new
                {
                    HaftalıkDegerlendirmeRaporuGozlemlerId = table.Column<int>(type: "int", nullable: false),
                    KursHaftalıkDegerlendirmeRaporuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu", x => new { x.HaftalıkDegerlendirmeRaporuGozlemlerId, x.KursHaftalıkDegerlendirmeRaporuId });
                    table.ForeignKey(
                        name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu_UT_HaftalıkDegerlendirmeRaporuGozlemlers_HaftalıkD~",
                        column: x => x.HaftalıkDegerlendirmeRaporuGozlemlerId,
                        principalTable: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu_UT_KursHaftalıkDegerlendirmeRaporus_KursHaftalıkDe~",
                        column: x => x.KursHaftalıkDegerlendirmeRaporuId,
                        principalTable: "UT_KursHaftalıkDegerlendirmeRaporus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu",
                column: "KursHaftalıkDegerlendirmeRaporuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.AddColumn<int>(
                name: "UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "UT_KursHaftalıkDegerlendirmeRaporuId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_UT_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "UT_KursHaftalıkDegerlendirmeRaporuId",
                principalTable: "UT_KursHaftalıkDegerlendirmeRaporus",
                principalColumn: "Id");
        }
    }
}
