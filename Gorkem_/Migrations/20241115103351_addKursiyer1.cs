using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addKursiyer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UT_Kursiyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KursId = table.Column<int>(type: "int", nullable: true),
                    Sicil = table.Column<int>(type: "int", nullable: true),
                    AdSoyad = table.Column<int>(type: "int", nullable: true),
                    BirimId = table.Column<int>(type: "int", nullable: true),
                    RutbeId = table.Column<int>(type: "int", nullable: true),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_Kursiyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UT_Kursiyer_KT_Birims_BirimId",
                        column: x => x.BirimId,
                        principalTable: "KT_Birims",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kursiyer_KT_Rutbes_RutbeId",
                        column: x => x.RutbeId,
                        principalTable: "KT_Rutbes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UT_Kursiyer_UT_Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_BirimId",
                table: "UT_Kursiyer",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_KursId",
                table: "UT_Kursiyer",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_RutbeId",
                table: "UT_Kursiyer",
                column: "RutbeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_Kursiyer");
        }
    }
}
