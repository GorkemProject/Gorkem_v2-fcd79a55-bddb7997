using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addBirimTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KT_Birims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabloID = table.Column<long>(type: "bigint", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktif = table.Column<bool>(type: "bit", nullable: false),
                    UstBirimID = table.Column<long>(type: "bigint", nullable: true),
                    UstBirimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UstBirimUzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimTuruID = table.Column<byte>(type: "tinyint", nullable: true),
                    BirimTuruAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGMBirimTuruID = table.Column<byte>(type: "tinyint", nullable: true),
                    EGMBirimTuruAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirimBransID = table.Column<byte>(type: "tinyint", nullable: true),
                    BirimBransAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlID = table.Column<long>(type: "bigint", nullable: true),
                    IlAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlUzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlceID = table.Column<long>(type: "bigint", nullable: true),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlceUzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KadroID = table.Column<long>(type: "bigint", nullable: true),
                    KadroAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KadroUzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeID = table.Column<long>(type: "bigint", nullable: true),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeUzunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YazismaKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AktifYazismaKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlPlakaNo = table.Column<byte>(type: "tinyint", nullable: true),
                    BuyukSehirmi = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Birims", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KT_Birims");
        }
    }
}
