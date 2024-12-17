using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class IdareciAdayIdareci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_OgrenimDurumus_UT_Idarecis_UT_IdareciId",
                table: "KT_OgrenimDurumus");

            migrationBuilder.DropForeignKey(
                name: "FK_KT_YabanciDils_UT_Idarecis_UT_IdareciId",
                table: "KT_YabanciDils");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_IdareciId",
                table: "UT_IdareciKopekleri");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.RenameColumn(
                name: "UT_IdareciId",
                table: "KT_YabanciDils",
                newName: "UT_AdayIdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_YabanciDils_UT_IdareciId",
                table: "KT_YabanciDils",
                newName: "IX_KT_YabanciDils_UT_AdayIdareciId");

            migrationBuilder.RenameColumn(
                name: "UT_IdareciId",
                table: "KT_OgrenimDurumus",
                newName: "UT_AdayIdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_OgrenimDurumus_UT_IdareciId",
                table: "KT_OgrenimDurumus",
                newName: "IX_KT_OgrenimDurumus_UT_AdayIdareciId");

            migrationBuilder.AddColumn<int>(
                name: "Durum",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "TestTarihi",
                table: "UT_Idarecis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TestiYapanId",
                table: "UT_Idarecis",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Idarecis_TestiYapanId",
                table: "UT_Idarecis",
                column: "TestiYapanId");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Idarecis_UT_KursEgitmenler_TestiYapanId",
                table: "UT_Idarecis",
                column: "TestiYapanId",
                principalTable: "UT_KursEgitmenler",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idareci_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idareci",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_UT_Idarecis_UT_KursEgitmenler_TestiYapanId",
                table: "UT_Idarecis");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idareci_IdareciId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropTable(
                name: "UT_Idareci");

            migrationBuilder.DropIndex(
                name: "IX_UT_Idarecis_TestiYapanId",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "Puan",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "TestTarihi",
                table: "UT_Idarecis");

            migrationBuilder.DropColumn(
                name: "TestiYapanId",
                table: "UT_Idarecis");

            migrationBuilder.RenameColumn(
                name: "UT_AdayIdareciId",
                table: "KT_YabanciDils",
                newName: "UT_IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_YabanciDils_UT_AdayIdareciId",
                table: "KT_YabanciDils",
                newName: "IX_KT_YabanciDils_UT_IdareciId");

            migrationBuilder.RenameColumn(
                name: "UT_AdayIdareciId",
                table: "KT_OgrenimDurumus",
                newName: "UT_IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_KT_OgrenimDurumus_UT_AdayIdareciId",
                table: "KT_OgrenimDurumus",
                newName: "IX_KT_OgrenimDurumus_UT_IdareciId");

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
                name: "FK_UT_IdareciKopekleri_UT_Idarecis_IdareciId",
                table: "UT_IdareciKopekleri",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Idarecis_IdareciId",
                table: "UT_KopekCalKads",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");
        }
    }
}
