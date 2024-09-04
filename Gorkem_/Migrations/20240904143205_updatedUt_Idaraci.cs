using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class updatedUt_Idaraci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Durums_DurumRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropColumn(
                name: "AskerlikDurumu",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Birim",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Kurum",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Ogrenim",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Rutbe",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "YabanciDil",
                table: "UT_Idarecis");

            migrationBuilder.RenameColumn(
                name: "IrkRef",
                table: "UT_Kopek_Kopeks",
                newName: "IrkId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_IrkRef",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_IrkId");

            migrationBuilder.AddColumn<int>(
                name: "AskerlikId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
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

            migrationBuilder.AddColumn<int>(
                name: "IdareciDurumId",
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

            migrationBuilder.CreateTable(
                name: "KT_Askerlik",
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
                    table.PrimaryKey("PK_KT_Askerlik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_KopekDurumu",
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
                    table.PrimaryKey("PK_KT_KopekDurumu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_OgrenimDurumu",
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
                    table.PrimaryKey("PK_KT_OgrenimDurumu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KT_OgrenimDurumu_UT_Idarecis_UT_IdareciId",
                        column: x => x.UT_IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KT_Rutbe",
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
                    table.PrimaryKey("PK_KT_Rutbe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_YabanciDil",
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
                    table.PrimaryKey("PK_KT_YabanciDil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KT_YabanciDil_UT_Idarecis_UT_IdareciId",
                        column: x => x.UT_IdareciId,
                        principalTable: "UT_Idarecis",
                        principalColumn: "Id");
                });

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
                name: "IX_KT_OgrenimDurumu_UT_IdareciId",
                table: "KT_OgrenimDurumu",
                column: "UT_IdareciId");

            migrationBuilder.CreateIndex(
                name: "IX_KT_YabanciDil_UT_IdareciId",
                table: "KT_YabanciDil",
                column: "UT_IdareciId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Askerlik_AskerlikId",
                table: "UT_Idarecis",
                column: "AskerlikId",
                principalTable: "KT_Askerlik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_KT_Birims_BirimId",
                table: "UT_Idarecis",
                column: "BirimId",
                principalTable: "KT_Birims",
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
                name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkId",
                table: "UT_Kopek_Kopeks",
                column: "IrkId",
                principalTable: "KT_Irks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumu_DurumRef",
                table: "UT_Kopek_Kopeks",
                column: "DurumRef",
                principalTable: "KT_KopekDurumu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Askerlik_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Birims_BirimId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Branss_BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Durums_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Idarecis_KT_Rutbe_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_Irks_IrkId",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kopek_Kopeks_KT_KopekDurumu_DurumRef",
                table: "UT_Kopek_Kopeks");

            migrationBuilder.DropTable(
                name: "KT_Askerlik");

            migrationBuilder.DropTable(
                name: "KT_KopekDurumu");

            migrationBuilder.DropTable(
                name: "KT_OgrenimDurumu");

            migrationBuilder.DropTable(
                name: "KT_Rutbe");

            migrationBuilder.DropTable(
                name: "KT_YabanciDil");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_BirimId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "AskerlikId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "BransId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "IdareciDurumId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "RutbeId",
                table: "UT_Idarecis");

            migrationBuilder.RenameColumn(
                name: "IrkId",
                table: "UT_Kopek_Kopeks",
                newName: "IrkRef");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kopek_Kopeks_IrkId",
                table: "UT_Kopek_Kopeks",
                newName: "IX_UT_Kopek_Kopeks_IrkRef");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UT_Kopek_Kopeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AskerlikDurumu",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Birim",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kurum",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ogrenim",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rutbe",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YabanciDil",
                table: "UT_Idarecis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
