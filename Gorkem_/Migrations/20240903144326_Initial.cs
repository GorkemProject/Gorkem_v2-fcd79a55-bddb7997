using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KT_Birims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Birims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KT_Branss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Branss", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KT_Durums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Durums", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KT_Irks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Irks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KT_KopekTurus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_KopekTurus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Hibes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdiSoyadi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonNumarasi = table.Column<int>(type: "int", nullable: false),
                    HibeEdilmeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Hibes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UT_Kopek_SatinAlmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdiSoyadi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresi = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonNumarasi = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_SatinAlmas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Uretims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KopekRef = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnneKopekRef = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BabaKopekRef = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Uretims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Kopeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrkRef = table.Column<int>(type: "int", nullable: false),
                    BirimRef = table.Column<int>(type: "int", nullable: false),
                    BransRef = table.Column<int>(type: "int", nullable: false),
                    KuvveNumarasi = table.Column<int>(type: "int", nullable: false),
                    CipNumarasi = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    YapilanIslem = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NihaiKanaat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KopekTuruRef = table.Column<int>(type: "int", nullable: false),
                    Karar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DurumRef = table.Column<int>(type: "int", nullable: false),
                    TeminSekli = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HibeId = table.Column<int>(type: "int", nullable: true),
                    SatinAlmaId = table.Column<int>(type: "int", nullable: true),
                    URETİMId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aktifmi = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Kopeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimRef",
                        column: x => x.BirimRef,
                        principalTable: "KT_Birims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Branss_BransRef",
                        column: x => x.BransRef,
                        principalTable: "KT_Branss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Durums_DurumRef",
                        column: x => x.DurumRef,
                        principalTable: "KT_Durums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkRef",
                        column: x => x.IrkRef,
                        principalTable: "KT_Irks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruRef",
                        column: x => x.KopekTuruRef,
                        principalTable: "KT_KopekTurus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_UT_Kopek_Hibes_HibeId",
                        column: x => x.HibeId,
                        principalTable: "UT_Kopek_Hibes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_UT_Kopek_SatinAlmas_SatinAlmaId",
                        column: x => x.SatinAlmaId,
                        principalTable: "UT_Kopek_SatinAlmas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_UT_Kopek_Uretims_URETİMId",
                        column: x => x.URETİMId,
                        principalTable: "UT_Kopek_Uretims",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimRef",
                table: "UT_Kopek_Kopeks",
                column: "BirimRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BransRef",
                table: "UT_Kopek_Kopeks",
                column: "BransRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_DurumRef",
                table: "UT_Kopek_Kopeks",
                column: "DurumRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_HibeId",
                table: "UT_Kopek_Kopeks",
                column: "HibeId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_IrkRef",
                table: "UT_Kopek_Kopeks",
                column: "IrkRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_SatinAlmaId",
                table: "UT_Kopek_Kopeks",
                column: "SatinAlmaId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_URETİMId",
                table: "UT_Kopek_Kopeks",
                column: "URETİMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_Kopek_Kopeks");

            migrationBuilder.DropTable(
                name: "KT_Birims");

            migrationBuilder.DropTable(
                name: "KT_Branss");

            migrationBuilder.DropTable(
                name: "KT_Durums");

            migrationBuilder.DropTable(
                name: "KT_Irks");

            migrationBuilder.DropTable(
                name: "KT_KopekTurus");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Hibes");

            migrationBuilder.DropTable(
                name: "UT_Kopek_SatinAlmas");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Uretims");
        }
    }
}
