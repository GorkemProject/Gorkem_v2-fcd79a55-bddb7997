using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciAdayIdareci1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_AdayIdareciId",
                table: "KT_OgrenimDurumus");

            migrationBuilder.DropForeignKey(
                name: "FK_KT_YabanciDils_UT_Idarecis_UT_AdayIdareciId",
                table: "KT_YabanciDils");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idareci_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Askerliks_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Branss_BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_IdareciDurum_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_KadroIls_KadroIlId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbes_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_UT_KursEgitmenler_TestiYapanId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idareci_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropTable(
                name: "UT_Idareci");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_KadroIlId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "CepTelefonu",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "KadroIlId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Puan",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Sicil",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "TestTarihi",
                table: "UT_Idarecis");

            migrationBuilder.RenameColumn(
                name: "TestiYapanId",
                table: "UT_Idarecis",
                newName: "IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Idarecis_TestiYapanId",
                table: "UT_Idarecis",
                newName: "IX_UT_Idarecis_IdareciId");

            migrationBuilder.CreateTable(
                name: "UT_AdayIdareci",
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
                    Puan = table.Column<int>(type: "int", nullable: false),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    TestiYapanId = table.Column<int>(type: "int", nullable: false),
                    TestTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_AdayIdareci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_KT_Askerliks_AskerlikId",
                        column: x => x.AskerlikId,
                        principalTable: "KT_Askerliks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_KT_Branss_BransId",
                        column: x => x.BransId,
                        principalTable: "KT_Branss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_KT_IdareciDurum_IdareciDurumId",
                        column: x => x.IdareciDurumId,
                        principalTable: "KT_IdareciDurum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_KT_KadroIls_KadroIlId",
                        column: x => x.KadroIlId,
                        principalTable: "KT_KadroIls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_KT_Rutbes_RutbeId",
                        column: x => x.RutbeId,
                        principalTable: "KT_Rutbes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_AdayIdareci_UT_KursEgitmenler_TestiYapanId",
                        column: x => x.TestiYapanId,
                        principalTable: "UT_KursEgitmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_AskerlikId",
                table: "UT_AdayIdareci",
                column: "AskerlikId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_BransId",
                table: "UT_AdayIdareci",
                column: "BransId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_IdareciDurumId",
                table: "UT_AdayIdareci",
                column: "IdareciDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_KadroIlId",
                table: "UT_AdayIdareci",
                column: "KadroIlId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_RutbeId",
                table: "UT_AdayIdareci",
                column: "RutbeId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_AdayIdareci_TestiYapanId",
                table: "UT_AdayIdareci",
                column: "TestiYapanId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_AdayIdareci_UT_AdayIdareciId",
                table: "KT_OgrenimDurumus",
                column: "UT_AdayIdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_YabanciDils_UT_AdayIdareci_UT_AdayIdareciId",
                table: "KT_YabanciDils",
                column: "UT_AdayIdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_UT_AdayIdareci_IdareciId",
                table: "UT_Idarecis",
                column: "IdareciId",
                principalTable: "UT_AdayIdareci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_AdayIdareci_UT_AdayIdareciId",
                table: "KT_OgrenimDurumus");

            migrationBuilder.DropForeignKey(
                name: "FK_KT_YabanciDils_UT_AdayIdareci_UT_AdayIdareciId",
                table: "KT_YabanciDils");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_UT_AdayIdareci_IdareciId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropTable(
                name: "UT_AdayIdareci");

            migrationBuilder.RenameColumn(
                name: "IdareciId",
                table: "UT_Idarecis",
                newName: "TestiYapanId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Idarecis_IdareciId",
                table: "UT_Idarecis",
                newName: "IX_UT_Idarecis_TestiYapanId");

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AskerlikId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BransId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CepTelefonu",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "UT_Idarecis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Durum",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdareciDurumId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KadroIlId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Puan",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RutbeId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sicil",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TestTarihi",
                table: "UT_Idarecis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UT_Idareci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdareciId = table.Column<int>(type: "int", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Idareci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Idareci_UT_Idarecis_IdareciId",
                        column: x => x.IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_UT_Idareci_IdareciId",
                table: "UT_Idareci",
                column: "IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_AdayIdareciId",
                table: "KT_OgrenimDurumus",
                column: "UT_AdayIdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_YabanciDils_UT_Idarecis_UT_AdayIdareciId",
                table: "KT_YabanciDils",
                column: "UT_AdayIdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idareci_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "IdareciId",
                principalTable: "UT_Idareci",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Askerliks_AskerlikId",
                table: "UT_Idarecis",
                column: "AskerlikId",
                principalTable: "KT_Askerliks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Branss_BransId",
                table: "UT_Idarecis",
                column: "BransId",
                principalTable: "KT_Branss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_IdareciDurum_IdareciDurumId",
                table: "UT_Idarecis",
                column: "IdareciDurumId",
                principalTable: "KT_IdareciDurum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_KadroIls_KadroIlId",
                table: "UT_Idarecis",
                column: "KadroIlId",
                principalTable: "KT_KadroIls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbes_RutbeId",
                table: "UT_Idarecis",
                column: "RutbeId",
                principalTable: "KT_Rutbes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_UT_KursEgitmenler_TestiYapanId",
                table: "UT_Idarecis",
                column: "TestiYapanId",
                principalTable: "UT_KursEgitmenler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idareci_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idareci",
                principalColumn: "Id");
        }
    }
}
