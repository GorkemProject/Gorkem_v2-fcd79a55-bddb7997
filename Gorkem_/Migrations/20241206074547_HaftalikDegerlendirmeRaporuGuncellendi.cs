using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class HaftalikDegerlendirmeRaporuGuncellendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer");

            migrationBuilder.DropTable(
                name: "UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.AlterColumn<int>(
                name: "KopekId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId",
                principalTable: "UT_KursHaftalıkDegerlendirmeRaporus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropColumn(
                name: "HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.AlterColumn<int>(
                name: "KopekId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu_KursHaftalıkDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlerUT_KursHaftalıkDegerlendirmeRaporu",
                column: "KursHaftalıkDegerlendirmeRaporuId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id");
        }
    }
}
