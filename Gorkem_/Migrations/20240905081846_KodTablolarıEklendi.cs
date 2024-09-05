using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KodTablolarıEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_OgrenimDurumu_UT_Idarecis_UT_IdareciId",
                table: "KT_OgrenimDurumu");

            migrationBuilder.DropForeignKey(
                name: "FK_KT_YabanciDil_UT_Idarecis_UT_IdareciId",
                table: "KT_YabanciDil");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Askerlik_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Durums_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbe_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Branss_BransRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Cinss_CinsRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumu_DurumRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_YabanciDil",
                table: "KT_YabanciDil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Rutbe",
                table: "KT_Rutbe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_OgrenimDurumu",
                table: "KT_OgrenimDurumu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_KopekDurumu",
                table: "KT_KopekDurumu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Durums",
                table: "KT_Durums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Askerlik",
                table: "KT_Askerlik");

            migrationBuilder.RenameTable(
                name: "KT_YabanciDil",
                newName: "KT_YabanciDils");

            migrationBuilder.RenameTable(
                name: "KT_Rutbe",
                newName: "KT_Rutbes");

            migrationBuilder.RenameTable(
                name: "KT_OgrenimDurumu",
                newName: "KT_OgrenimDurumus");

            migrationBuilder.RenameTable(
                name: "KT_KopekDurumu",
                newName: "KT_KopekDurumus");

            migrationBuilder.RenameTable(
                name: "KT_Durums",
                newName: "KT_IdareciDurum");

            migrationBuilder.RenameTable(
                name: "KT_Askerlik",
                newName: "KT_Askerliks");

            migrationBuilder.RenameColumn(
                name: "KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                newName: "KopekTuruId");

            migrationBuilder.RenameColumn(
                name: "DurumRef",
                table: "UT_Kopek_Kopeks",
                newName: "DurumId");

            migrationBuilder.RenameColumn(
                name: "CinsRef",
                table: "UT_Kopek_Kopeks",
                newName: "CinsId");

            migrationBuilder.RenameColumn(
                name: "BransRef",
                table: "UT_Kopek_Kopeks",
                newName: "BransId");

            migrationBuilder.RenameColumn(
                name: "BirimRef",
                table: "UT_Kopek_Kopeks",
                newName: "BirimId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_KopekTuruId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_DurumRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_DurumId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_CinsRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_CinsId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_BransRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_BransId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_BirimRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_BirimId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_YabanciDil_UT_IdareciId",
                table: "KT_YabanciDils",
                newName: "IX_KT_YabanciDils_UT_IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_OgrenimDurumu_UT_IdareciId",
                table: "KT_OgrenimDurumus",
                newName: "IX_KT_OgrenimDurumus_UT_IdareciId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_YabanciDils",
                table: "KT_YabanciDils",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Rutbes",
                table: "KT_Rutbes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_OgrenimDurumus",
                table: "KT_OgrenimDurumus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_KopekDurumus",
                table: "KT_KopekDurumus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_IdareciDurum",
                table: "KT_IdareciDurum",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Askerliks",
                table: "KT_Askerliks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_IdareciId",
                table: "KT_OgrenimDurumus",
                column: "UT_IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_YabanciDils_UT_Idarecis_UT_IdareciId",
                table: "KT_YabanciDils",
                column: "UT_IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Askerliks_AskerlikId",
                table: "UT_Idarecis",
                column: "AskerlikId",
                principalTable: "KT_Askerliks",
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
                name: "FK_UT_Idarecis_KT_Rutbes_RutbeId",
                table: "UT_Idarecis",
                column: "RutbeId",
                principalTable: "KT_Rutbes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Branss_BransId",
                table: "UT_Kopek_Kopeks",
                column: "BransId",
                principalTable: "KT_Branss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Cinss_CinsId",
                table: "UT_Kopek_Kopeks",
                column: "CinsId",
                principalTable: "KT_Cinss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumus_DurumId",
                table: "UT_Kopek_Kopeks",
                column: "DurumId",
                principalTable: "KT_KopekDurumus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruId",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruId",
                principalTable: "KT_KopekTurus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_IdareciId",
                table: "KT_OgrenimDurumus");

            migrationBuilder.DropForeignKey(
                name: "FK_KT_YabanciDils_UT_Idarecis_UT_IdareciId",
                table: "KT_YabanciDils");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Askerliks_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_IdareciDurum_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbes_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Branss_BransId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Cinss_CinsId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumus_DurumId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_YabanciDils",
                table: "KT_YabanciDils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Rutbes",
                table: "KT_Rutbes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_OgrenimDurumus",
                table: "KT_OgrenimDurumus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_KopekDurumus",
                table: "KT_KopekDurumus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_IdareciDurum",
                table: "KT_IdareciDurum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Askerliks",
                table: "KT_Askerliks");

            migrationBuilder.RenameTable(
                name: "KT_YabanciDils",
                newName: "KT_YabanciDil");

            migrationBuilder.RenameTable(
                name: "KT_Rutbes",
                newName: "KT_Rutbe");

            migrationBuilder.RenameTable(
                name: "KT_OgrenimDurumus",
                newName: "KT_OgrenimDurumu");

            migrationBuilder.RenameTable(
                name: "KT_KopekDurumus",
                newName: "KT_KopekDurumu");

            migrationBuilder.RenameTable(
                name: "KT_IdareciDurum",
                newName: "KT_Durums");

            migrationBuilder.RenameTable(
                name: "KT_Askerliks",
                newName: "KT_Askerlik");

            migrationBuilder.RenameColumn(
                name: "KopekTuruId",
                table: "UT_Kopek_Kopeks",
                newName: "KopekTuruRef");

            migrationBuilder.RenameColumn(
                name: "DurumId",
                table: "UT_Kopek_Kopeks",
                newName: "DurumRef");

            migrationBuilder.RenameColumn(
                name: "CinsId",
                table: "UT_Kopek_Kopeks",
                newName: "CinsRef");

            migrationBuilder.RenameColumn(
                name: "BransId",
                table: "UT_Kopek_Kopeks",
                newName: "BransRef");

            migrationBuilder.RenameColumn(
                name: "BirimId",
                table: "UT_Kopek_Kopeks",
                newName: "BirimRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_KopekTuruId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_KopekTuruRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_DurumId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_DurumRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_CinsId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_CinsRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_BransId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_BransRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_BirimId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_BirimRef");

            migrationBuilder.RenameIndex(
                name: "IX_KT_YabanciDils_UT_IdareciId",
                table: "KT_YabanciDil",
                newName: "IX_KT_YabanciDil_UT_IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_OgrenimDurumus_UT_IdareciId",
                table: "KT_OgrenimDurumu",
                newName: "IX_KT_OgrenimDurumu_UT_IdareciId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_YabanciDil",
                table: "KT_YabanciDil",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Rutbe",
                table: "KT_Rutbe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_OgrenimDurumu",
                table: "KT_OgrenimDurumu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_KopekDurumu",
                table: "KT_KopekDurumu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Durums",
                table: "KT_Durums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Askerlik",
                table: "KT_Askerlik",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_OgrenimDurumu_UT_Idarecis_UT_IdareciId",
                table: "KT_OgrenimDurumu",
                column: "UT_IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_YabanciDil_UT_Idarecis_UT_IdareciId",
                table: "KT_YabanciDil",
                column: "UT_IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Askerlik_AskerlikId",
                table: "UT_Idarecis",
                column: "AskerlikId",
                principalTable: "KT_Askerlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Durums_IdareciDurumId",
                table: "UT_Idarecis",
                column: "IdareciDurumId",
                principalTable: "KT_Durums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbe_RutbeId",
                table: "UT_Idarecis",
                column: "RutbeId",
                principalTable: "KT_Rutbe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimRef",
                table: "UT_Kopek_Kopeks",
                column: "BirimRef",
                principalTable: "KT_Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Branss_BransRef",
                table: "UT_Kopek_Kopeks",
                column: "BransRef",
                principalTable: "KT_Branss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Cinss_CinsRef",
                table: "UT_Kopek_Kopeks",
                column: "CinsRef",
                principalTable: "KT_Cinss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumu_DurumRef",
                table: "UT_Kopek_Kopeks",
                column: "DurumRef",
                principalTable: "KT_KopekDurumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruRef",
                principalTable: "KT_KopekTurus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
