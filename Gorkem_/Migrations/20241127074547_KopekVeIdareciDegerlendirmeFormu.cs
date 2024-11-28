using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekVeIdareciDegerlendirmeFormu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KT_KursKopekDegerlendirmeSorular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxPuan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KursKopekDegerlendirmeSorular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_KursKursiyerDegerlendirmeSorular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxPuan = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KursKursiyerDegerlendirmeSorular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    KursiyerId = table.Column<int>(type: "int", nullable: false),
                    TestinYapildigiIlId = table.Column<int>(type: "int", nullable: false),
                    TestinYapildigiYer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KursId = table.Column<int>(type: "int", nullable: false),
                    KapaliAlanToplamPuan = table.Column<int>(type: "int", nullable: false),
                    AracToplamPuan = table.Column<int>(type: "int", nullable: false),
                    TasinabilirEsyaToplamPuan = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KopekVeIdareciDegerlendirmeFormu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_KT_GorevYeris_TestinYapildigiIlId",
                        column: x => x.TestinYapildigiIlId,
                        principalTable: "KT_GorevYeris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_IdareciKopekleri_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_IdareciKopekleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KopekVeIdareciDegerlendirmeFormu_UT_Kursiyer_KursiyerId",
                        column: x => x.KursiyerId,
                        principalTable: "UT_Kursiyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KursKopekDegerlendirmeCevap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekDegerlendirmeSoruId = table.Column<int>(type: "int", nullable: false),
                    KopekDegerlendirmeSorularId = table.Column<int>(type: "int", nullable: true),
                    KapaliAlanPuan = table.Column<int>(type: "int", nullable: false),
                    AracPuan = table.Column<int>(type: "int", nullable: false),
                    TasinabilirEsyaPuan = table.Column<int>(type: "int", nullable: false),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    UT_KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursKopekDegerlendirmeCevap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursKopekDegerlendirmeCevap_KT_KursKopekDegerlendirmeSorular_KopekDegerlendirmeSorularId",
                        column: x => x.KopekDegerlendirmeSorularId,
                        principalTable: "KT_KursKopekDegerlendirmeSorular",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                        column: x => x.UT_KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_KursKopekDegerlendirmeCevap_UT_Kopek_Kopeks_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_KursKursiyerDegerlendirmeCevap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursiyerDegerlendirmeSoruId = table.Column<int>(type: "int", nullable: false),
                    KapaliAlanPuan = table.Column<int>(type: "int", nullable: false),
                    AracPuan = table.Column<int>(type: "int", nullable: false),
                    TasinabilirEsyaPuan = table.Column<int>(type: "int", nullable: false),
                    KursiyerId = table.Column<int>(type: "int", nullable: false),
                    UT_KopekVeIdareciDegerlendirmeFormuId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursKursiyerDegerlendirmeCevap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursKursiyerDegerlendirmeCevap_KT_KursKursiyerDegerlendirmeSorular_KursiyerDegerlendirmeSoruId",
                        column: x => x.KursiyerDegerlendirmeSoruId,
                        principalTable: "KT_KursKursiyerDegerlendirmeSorular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                        column: x => x.UT_KopekVeIdareciDegerlendirmeFormuId,
                        principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_KursKursiyerDegerlendirmeCevap_UT_Kursiyer_KursiyerId",
                        column: x => x.KursiyerId,
                        principalTable: "UT_Kursiyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KopekId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KursId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_KursiyerId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "KursiyerId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KopekVeIdareciDegerlendirmeFormu_TestinYapildigiIlId",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                column: "TestinYapildigiIlId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekDegerlendirmeSorularId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekDegerlendirmeSorularId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_KopekId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKopekDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKopekDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_KursiyerDegerlendirmeSoruId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerDegerlendirmeSoruId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_KursiyerId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "KursiyerId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursKursiyerDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursKursiyerDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KursKopekDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "UT_KursKursiyerDegerlendirmeCevap");

            migrationBuilder.DropTable(
                name: "KT_KursKopekDegerlendirmeSorular");

            migrationBuilder.DropTable(
                name: "KT_KursKursiyerDegerlendirmeSorular");

            migrationBuilder.DropTable(
                name: "UT_KopekVeIdareciDegerlendirmeFormu");
        }
    }
}
