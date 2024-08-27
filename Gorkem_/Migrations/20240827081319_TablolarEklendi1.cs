using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class TablolarEklendi1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_Birims_BirimRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_Branss_BransRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_Durums_DurumRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_Irks_IrkRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_Kopek_Hibes_HibeId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KopekTurus",
                table: "KopekTurus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kopek_Hibes",
                table: "Kopek_Hibes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Irks",
                table: "Irks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Durums",
                table: "Durums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Branss",
                table: "Branss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Birims",
                table: "Birims");

            migrationBuilder.RenameTable(
                name: "KopekTurus",
                newName: "KT_KopekTurus");

            migrationBuilder.RenameTable(
                name: "Kopek_Hibes",
                newName: "UT_Kopek_Hibes");

            migrationBuilder.RenameTable(
                name: "Irks",
                newName: "KT_Irks");

            migrationBuilder.RenameTable(
                name: "Durums",
                newName: "KT_Durums");

            migrationBuilder.RenameTable(
                name: "Branss",
                newName: "KT_Branss");

            migrationBuilder.RenameTable(
                name: "Birims",
                newName: "KT_Birims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_KopekTurus",
                table: "KT_KopekTurus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_Kopek_Hibes",
                table: "UT_Kopek_Hibes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Irks",
                table: "KT_Irks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Durums",
                table: "KT_Durums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Branss",
                table: "KT_Branss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KT_Birims",
                table: "KT_Birims",
                column: "Id");

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
                name: "FK_UT_Kopek_Kopeks_KT_Durums_DurumRef",
                table: "UT_Kopek_Kopeks",
                column: "DurumRef",
                principalTable: "KT_Durums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkRef",
                table: "UT_Kopek_Kopeks",
                column: "IrkRef",
                principalTable: "KT_Irks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruRef",
                principalTable: "KT_KopekTurus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_UT_Kopek_Hibes_HibeId",
                table: "UT_Kopek_Kopeks",
                column: "HibeId",
                principalTable: "UT_Kopek_Hibes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Birims_BirimRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Branss_BransRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Durums_DurumRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_UT_Kopek_Hibes_HibeId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_Kopek_Hibes",
                table: "UT_Kopek_Hibes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_KopekTurus",
                table: "KT_KopekTurus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Irks",
                table: "KT_Irks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Durums",
                table: "KT_Durums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Branss",
                table: "KT_Branss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KT_Birims",
                table: "KT_Birims");

            migrationBuilder.RenameTable(
                name: "UT_Kopek_Hibes",
                newName: "Kopek_Hibes");

            migrationBuilder.RenameTable(
                name: "KT_KopekTurus",
                newName: "KopekTurus");

            migrationBuilder.RenameTable(
                name: "KT_Irks",
                newName: "Irks");

            migrationBuilder.RenameTable(
                name: "KT_Durums",
                newName: "Durums");

            migrationBuilder.RenameTable(
                name: "KT_Branss",
                newName: "Branss");

            migrationBuilder.RenameTable(
                name: "KT_Birims",
                newName: "Birims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kopek_Hibes",
                table: "Kopek_Hibes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KopekTurus",
                table: "KopekTurus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Irks",
                table: "Irks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Durums",
                table: "Durums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Branss",
                table: "Branss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Birims",
                table: "Birims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_Birims_BirimRef",
                table: "UT_Kopek_Kopeks",
                column: "BirimRef",
                principalTable: "Birims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_Branss_BransRef",
                table: "UT_Kopek_Kopeks",
                column: "BransRef",
                principalTable: "Branss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_Durums_DurumRef",
                table: "UT_Kopek_Kopeks",
                column: "DurumRef",
                principalTable: "Durums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_Irks_IrkRef",
                table: "UT_Kopek_Kopeks",
                column: "IrkRef",
                principalTable: "Irks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KopekTurus_KopekTuruRef",
                table: "UT_Kopek_Kopeks",
                column: "KopekTuruRef",
                principalTable: "KopekTurus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_Kopek_Hibes_HibeId",
                table: "UT_Kopek_Kopeks",
                column: "HibeId",
                principalTable: "Kopek_Hibes",
                principalColumn: "Id");
        }
    }
}
