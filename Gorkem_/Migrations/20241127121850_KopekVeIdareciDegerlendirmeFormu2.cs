using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekVeIdareciDegerlendirmeFormu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_IdareciKopekleri_KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_Kursiyer_KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropColumn(
                name: "UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropColumn(
                name: "UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropColumn(
                name: "KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.DropColumn(
                name: "KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu");

            migrationBuilder.AlterColumn<int>(
                name: "TasinabilirEsyaToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KapaliAlanToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AracToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap",
                columns: table => new
                {
                    KopekDegerlendirmeCevaplarId = table.Column<int>(type: "int", nullable: false),
                    KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap", x => new { x.KopekDegerlendirmeCevaplarId, x.KopekVeIdareciDegerlendirmeFormuId });
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_KopekVeIdareciDegerlen~",
                        column: x => x.KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeCevaplarId",
                        column: x => x.KopekDegerlendirmeCevaplarId,
                        principalTable: "UT_KursKopekDegerlendirmeCevap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap",
                columns: table => new
                {
                    KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: false),
                    KursiyerDegerlendirmeCevaplarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap", x => new { x.KopekVeIdareciDegerlendirmeFormuId, x.KursiyerDegerlendirmeCevaplarId });
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_KopekVeIdareciDeger~",
                        column: x => x.KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_UT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirme~",
                        column: x => x.KursiyerDegerlendirmeCevaplarId,
                        principalTable: "UT_KursKursiyerDegerlendirmeCevap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap",
                column: "KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirmeCevaplarId",
                table: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerDegerlendirmeCevaplarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormuUT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.AddColumn<int>(
                name: "UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TasinabilirEsyaToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KapaliAlanToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AracToplamPuan",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KursiyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_IdareciKopekleri_KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KopekId",
                principalTable: "UT_IdareciKopekleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_Kursiyer_KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KursiyerId",
                principalTable: "UT_Kursiyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId",
                principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId",
                principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                principalColumn: "Id");
        }
    }
}
