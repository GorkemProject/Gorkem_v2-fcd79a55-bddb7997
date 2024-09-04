using System;
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
            migrationBuilder.CreateTable(
                name: "KT_Birims",
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
                    table.PrimaryKey("PK_KT_Birims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Branss",
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
                    table.PrimaryKey("PK_KT_Branss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Cinss",
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
                    table.PrimaryKey("PK_KT_Cinss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Durums",
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
                    table.PrimaryKey("PK_KT_Durums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Irks",
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
                    table.PrimaryKey("PK_KT_Irks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_KopekTurus",
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
                    table.PrimaryKey("PK_KT_KopekTurus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_Idarecis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sicil = table.Column<int>(type: "int", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rutbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kurum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AskerlikDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ogrenim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YabanciDil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Idarecis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Hibes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNumarasi = table.Column<int>(type: "int", nullable: false),
                    HibeEdilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Hibes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_Kopek_SatinAlmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNumarasi = table.Column<int>(type: "int", nullable: false),
                    SatinAlmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_SatinAlmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Uretims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnneKopekRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BabaKopekRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KopekKopekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Uretims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UT_Kopek_Kopeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IrkRef = table.Column<int>(type: "int", nullable: false),
                    BirimRef = table.Column<int>(type: "int", nullable: false),
                    BransRef = table.Column<int>(type: "int", nullable: false),
                    KuvveNumarasi = table.Column<int>(type: "int", nullable: false),
                    CipNumarasi = table.Column<int>(type: "int", nullable: false),
                    CinsRef = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YapilanIslem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NihaiKanaat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KopekTuruRef = table.Column<int>(type: "int", nullable: false),
                    Karar = table.Column<bool>(type: "bit", nullable: false),
                    DurumRef = table.Column<int>(type: "int", nullable: false),
                    TeminSekli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HibeId = table.Column<int>(type: "int", nullable: true),
                    SatinAlmaId = table.Column<int>(type: "int", nullable: true),
                    URETİMId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_UT_Kopek_Kopeks_KT_Cinss_CinsRef",
                        column: x => x.CinsRef,
                        principalTable: "KT_Cinss",
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimRef",
                table: "UT_Kopek_Kopeks",
                column: "BirimRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BransRef",
                table: "UT_Kopek_Kopeks",
                column: "BransRef");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_CinsRef",
                table: "UT_Kopek_Kopeks",
                column: "CinsRef");

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
                name: "UT_Idarecis");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Kopeks");

            migrationBuilder.DropTable(
                name: "KT_Birims");

            migrationBuilder.DropTable(
                name: "KT_Branss");

            migrationBuilder.DropTable(
                name: "KT_Cinss");

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
