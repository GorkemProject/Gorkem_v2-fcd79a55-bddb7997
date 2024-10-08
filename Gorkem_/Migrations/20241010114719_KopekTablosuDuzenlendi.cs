﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekTablosuDuzenlendi : Migration
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
                name: "KT_KadroIls",
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
                    table.PrimaryKey("PK_KT_KadroIls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Karars",
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
                    table.PrimaryKey("PK_KT_Karars", x => x.Id);
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
                name: "UT_Kopek_Kopeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IrkId = table.Column<int>(type: "int", nullable: false),
                    BransId = table.Column<int>(type: "int", nullable: false),
                    KuvveNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CipNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KadroIlId = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YapilanIslem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NihaiKanaat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KararId = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    EdinimSekli = table.Column<int>(type: "int", nullable: false),
                    BabaKopekId = table.Column<int>(type: "int", nullable: true),
                    AnneKopekId = table.Column<int>(type: "int", nullable: true),
                    EdinilenKisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdinilenKisiAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdinilenKisiTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdinilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kopek_Kopeks", x => x.Id);
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
                        name: "FK_UT_Kopek_Kopeks_KT_KadroIls_KadroIlId",
                        column: x => x.KadroIlId,
                        principalTable: "KT_KadroIls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_KT_Karars_KararId",
                        column: x => x.KararId,
                        principalTable: "KT_Karars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_UT_Kopek_Kopeks_AnneKopekId",
                        column: x => x.AnneKopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kopek_Kopeks_UT_Kopek_Kopeks_BabaKopekId",
                        column: x => x.BabaKopekId,
                        principalTable: "UT_Kopek_Kopeks",
                        principalColumn: "Id");
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
                    KadroIlId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_UT_Idarecis_KT_KadroIls_KadroIlId",
                        column: x => x.KadroIlId,
                        principalTable: "KT_KadroIls",
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
                name: "IX_UT_Idarecis_BransId",
                table: "UT_Idarecis",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_IdareciDurumId",
                table: "UT_Idarecis",
                column: "IdareciDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_KadroIlId",
                table: "UT_Idarecis",
                column: "KadroIlId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_RutbeId",
                table: "UT_Idarecis",
                column: "RutbeId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_AnneKopekId",
                table: "UT_Kopek_Kopeks",
                column: "AnneKopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BabaKopekId",
                table: "UT_Kopek_Kopeks",
                column: "BabaKopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_BransId",
                table: "UT_Kopek_Kopeks",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_IrkId",
                table: "UT_Kopek_Kopeks",
                column: "IrkId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_KadroIlId",
                table: "UT_Kopek_Kopeks",
                column: "KadroIlId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kopek_Kopeks_KararId",
                table: "UT_Kopek_Kopeks",
                column: "KararId");
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
                name: "KT_Branss");

            migrationBuilder.DropTable(
                name: "KT_Irks");

            migrationBuilder.DropTable(
                name: "KT_KadroIls");

            migrationBuilder.DropTable(
                name: "KT_Karars");
        }
    }
}
