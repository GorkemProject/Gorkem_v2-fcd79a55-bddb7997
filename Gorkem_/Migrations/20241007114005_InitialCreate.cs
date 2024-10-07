using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KT_Askerliks",
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
                    table.PrimaryKey("PK_KT_Askerliks", x => x.Id);
                });

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
                name: "KT_IdareciDurum",
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
                    table.PrimaryKey("PK_KT_IdareciDurum", x => x.Id);
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
                name: "KT_KopekDurumus",
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
                    table.PrimaryKey("PK_KT_KopekDurumus", x => x.Id);
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
                name: "KT_Rutbes",
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
                    table.PrimaryKey("PK_KT_Rutbes", x => x.Id);
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
                    HibeEdilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    SatinAlmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    BabaKopekRef = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    KopekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IrkId = table.Column<int>(type: "int", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false),
                    KuvveNumarasi = table.Column<int>(type: "int", nullable: false),
                    CipNumarasi = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YapilanIslem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NihaiKanaat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KopekTuruId = table.Column<int>(type: "int", nullable: false),
                    Karar = table.Column<bool>(type: "bit", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Kopeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "KT_Birims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Branss_BransId",
                        column: x => x.BransId,
                        principalTable: "KT_Branss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkId",
                        column: x => x.IrkId,
                        principalTable: "KT_Irks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruId",
                        column: x => x.KopekTuruId,
                        principalTable: "KT_KopekTurus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UT_Idarecis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sicil = table.Column<int>(type: "int", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CepTelefonu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdareciDurumId = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false),
                    RutbeId = table.Column<int>(type: "int", nullable: false),
                    AskerlikId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Idarecis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Idarecis_KT_Askerliks_AskerlikId",
                        column: x => x.AskerlikId,
                        principalTable: "KT_Askerliks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Idarecis_KT_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "KT_Birims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Idarecis_KT_Branss_BransId",
                        column: x => x.BransId,
                        principalTable: "KT_Branss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Idarecis_KT_IdareciDurum_IdareciDurumId",
                        column: x => x.IdareciDurumId,
                        principalTable: "KT_IdareciDurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Idarecis_KT_Rutbes_RutbeId",
                        column: x => x.RutbeId,
                        principalTable: "KT_Rutbes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KT_OgrenimDurumus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UT_IdareciId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_OgrenimDurumus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_IdareciId",
                        column: x => x.UT_IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KT_YabanciDils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UT_IdareciId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_YabanciDils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KT_YabanciDils_UT_Idarecis_UT_IdareciId",
                        column: x => x.UT_IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UT_IdareciKopekleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekId = table.Column<int>(type: "int", nullable: false),
                    IdareciId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_IdareciKopekleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_IdareciKopekleri_UT_Idarecis_IdareciId",
                        column: x => x.IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UT_IdareciKopekleri_UT_Kopek_Kopeks_KopekId",
                        column: x => x.KopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KT_OgrenimDurumus_UT_IdareciId",
                table: "KT_OgrenimDurumus",
                column: "UT_IdareciId");

            migrationBuilder.CreateIndex(
                name: "IX_KT_YabanciDils_UT_IdareciId",
                table: "KT_YabanciDils",
                column: "UT_IdareciId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_IdareciKopekleri_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "IdareciId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_IdareciKopekleri_KopekId",
                table: "UT_IdareciKopekleri",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_AskerlikId",
                table: "UT_Idarecis",
                column: "AskerlikId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_BirimId",
                table: "UT_Idarecis",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_BransId",
                table: "UT_Idarecis",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_IdareciDurumId",
                table: "UT_Idarecis",
                column: "IdareciDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_RutbeId",
                table: "UT_Idarecis",
                column: "RutbeId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BransId",
                table: "UT_Kopek_Kopeks",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_IrkId",
                table: "UT_Kopek_Kopeks",
                column: "IrkId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_KopekTuruId",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KT_Cinss");

            migrationBuilder.DropTable(
                name: "KT_KopekDurumus");

            migrationBuilder.DropTable(
                name: "KT_OgrenimDurumus");

            migrationBuilder.DropTable(
                name: "KT_YabanciDils");

            migrationBuilder.DropTable(
                name: "UT_IdareciKopekleri");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Hibes");

            migrationBuilder.DropTable(
                name: "UT_Kopek_SatinAlmas");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Uretims");

            migrationBuilder.DropTable(
                name: "UT_Idarecis");

            migrationBuilder.DropTable(
                name: "UT_Kopek_Kopeks");

            migrationBuilder.DropTable(
                name: "KT_Askerliks");

            migrationBuilder.DropTable(
                name: "KT_IdareciDurum");

            migrationBuilder.DropTable(
                name: "KT_Rutbes");

            migrationBuilder.DropTable(
                name: "KT_Birims");

            migrationBuilder.DropTable(
                name: "KT_Branss");

            migrationBuilder.DropTable(
                name: "KT_Irks");

            migrationBuilder.DropTable(
                name: "KT_KopekTurus");
        }
    }
}
