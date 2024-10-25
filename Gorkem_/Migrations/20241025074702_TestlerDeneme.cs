using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class TestlerDeneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KT_SecimTests",
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
                    table.PrimaryKey("PK_KT_SecimTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KT_Sorus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puan = table.Column<int>(type: "int", nullable: false),
                    KT_SecimTestId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktifmi = table.Column<bool>(type: "bit", nullable: false),
                    T_Aktif = table.Column<DateTime>(type: "datetime2", nullable: false),
                    T_Pasif = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KT_Sorus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KT_Sorus_KT_SecimTests_KT_SecimTestId",
                        column: x => x.KT_SecimTestId,
                        principalTable: "KT_SecimTests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KT_Sorus_KT_SecimTestId",
                table: "KT_Sorus",
                column: "KT_SecimTestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KT_Sorus");

            migrationBuilder.DropTable(
                name: "KT_SecimTests");
        }
    }
}
