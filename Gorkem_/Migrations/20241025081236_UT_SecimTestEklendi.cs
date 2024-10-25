using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class UT_SecimTestEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_SecimTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    IdareciId = table.Column<int>(type: "int", nullable: false),
                    SecimTestId = table.Column<int>(type: "int", nullable: false),
                    SinavYeriId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TepkiSekli = table.Column<bool>(type: "bit", nullable: false),
                    Havlama = table.Column<bool>(type: "bit", nullable: false),
                    SecimTestBrans = table.Column<int>(type: "int", nullable: false),
                    Degerlendirme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestKomisyonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplamPuan = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_SecimTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_SecimTests_KT_GorevYeris_SinavYeriId",
                        column: x => x.SinavYeriId,
                        principalTable: "KT_GorevYeris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UT_SecimTests_KT_SecimTests_SecimTestId",
                        column: x => x.SecimTestId,
                        principalTable: "KT_SecimTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UT_SecimTests_UT_Idarecis_IdareciId",
                        column: x => x.IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UT_SecimTests_UT_Kopek_Kopeks_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_IdareciId",
                table: "UT_SecimTests",
                column: "IdareciId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_KopekId",
                table: "UT_SecimTests",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_SecimTestId",
                table: "UT_SecimTests",
                column: "SecimTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_SecimTests_SinavYeriId",
                table: "UT_SecimTests",
                column: "SinavYeriId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_SecimTests");
        }
    }
}
