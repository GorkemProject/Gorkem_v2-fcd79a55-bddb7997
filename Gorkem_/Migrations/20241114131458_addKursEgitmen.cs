using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addKursEgitmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_KursEgitmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: true),
                    Sicil = table.Column<int>(type: "int", nullable: false),
                    BirimId = table.Column<int>(type: "int", nullable: true),
                    RutbeId = table.Column<int>(type: "int", nullable: true),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursEgitmenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_KursEgitmenler_KT_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "KT_Birims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_KursEgitmenler_KT_Rutbes_RutbeId",
                        column: x => x.RutbeId,
                        principalTable: "KT_Rutbes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_KursEgitmenler_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursEgitmenler_BirimId",
                table: "UT_KursEgitmenler",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursEgitmenler_KursId",
                table: "UT_KursEgitmenler",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursEgitmenler_RutbeId",
                table: "UT_KursEgitmenler",
                column: "RutbeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KursEgitmenler");
        }
    }
}
