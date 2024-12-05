using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class kursiyerGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer");


            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_IdareciId",
                table: "UT_Kursiyer");

            migrationBuilder.RenameColumn(
                name: "IdareciId",
                table: "UT_Kursiyer",
                newName: "Sicil");

            migrationBuilder.AddColumn<string>(
                name: "CipNumarası",
                table: "UT_Kursiyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KopekId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonelAdi",
                table: "UT_Kursiyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestinYapildigiYer",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");


            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_KopekId",
                table: "UT_Kursiyer",
                column: "KopekId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_KursId",
                table: "UT_Kursiyer",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_KursId",
                table: "UT_Kursiyer",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kopek_Kopeks_KopekId",
                table: "UT_Kursiyer");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_KursId",
                table: "UT_Kursiyer");


            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_KopekId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "CipNumarası",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "KopekId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "PersonelAdi",
                table: "UT_Kursiyer");

            migrationBuilder.RenameColumn(
                name: "Sicil",
                table: "UT_Kursiyer",
                newName: "IdareciId");

            migrationBuilder.AlterColumn<string>(
                name: "TestinYapildigiYer",
                table: "UT_KopekVeIdareciDegerlendirmeFormu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);



            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_IdareciId",
                table: "UT_Kursiyer",
                column: "IdareciId");



            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
