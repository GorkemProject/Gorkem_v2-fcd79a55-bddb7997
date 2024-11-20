using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class mufredatInKursGunlukRapor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KT_KursMufredats_UT_KGRMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KGRMufredats_UT_KursGunlukRapors_UT_KursGunlukRaporId",
                table: "UT_KGRMufredats");

            migrationBuilder.DropIndex(
                name: "IX_UT_KGRMufredats_UT_KursGunlukRaporId",
                table: "UT_KGRMufredats");

            migrationBuilder.DropIndex(
                name: "IX_KT_KursMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats");

            migrationBuilder.DropColumn(
                name: "UT_KursGunlukRaporId",
                table: "UT_KGRMufredats");

            migrationBuilder.DropColumn(
                name: "UT_KGRMufredatId",
                table: "KT_KursMufredats");

            migrationBuilder.AddColumn<int>(
                name: "MufredatId",
                table: "UT_KGRMufredats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UT_KGRMufredatUT_KursGunlukRapor",
                columns: table => new
                {
                    KGRMufredatlarId = table.Column<int>(type: "int", nullable: false),
                    KursGunlukRaporId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KGRMufredatUT_KursGunlukRapor", x => new { x.KGRMufredatlarId, x.KursGunlukRaporId });
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredatUT_KursGunlukRapor_UT_KGRMufredats_KGRMufredatlarId",
                        column: x => x.KGRMufredatlarId,
                        principalTable: "UT_KGRMufredats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KGRMufredatUT_KursGunlukRapor_UT_KursGunlukRapors_KursGunlukRaporId",
                        column: x => x.KursGunlukRaporId,
                        principalTable: "UT_KursGunlukRapors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredats_MufredatId",
                table: "UT_KGRMufredats",
                column: "MufredatId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredatUT_KursGunlukRapor_KursGunlukRaporId",
                table: "UT_KGRMufredatUT_KursGunlukRapor",
                column: "KursGunlukRaporId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KGRMufredats_KT_KursMufredats_MufredatId",
                table: "UT_KGRMufredats",
                column: "MufredatId",
                principalTable: "KT_KursMufredats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KGRMufredats_KT_KursMufredats_MufredatId",
                table: "UT_KGRMufredats");

            migrationBuilder.DropTable(
                name: "UT_KGRMufredatUT_KursGunlukRapor");

            migrationBuilder.DropIndex(
                name: "IX_UT_KGRMufredats_MufredatId",
                table: "UT_KGRMufredats");

            migrationBuilder.DropColumn(
                name: "MufredatId",
                table: "UT_KGRMufredats");

            migrationBuilder.AddColumn<int>(
                name: "UT_KursGunlukRaporId",
                table: "UT_KGRMufredats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UT_KGRMufredatId",
                table: "KT_KursMufredats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_KGRMufredats_UT_KursGunlukRaporId",
                table: "UT_KGRMufredats",
                column: "UT_KursGunlukRaporId");

            migrationBuilder.CreateIndex(
                name: "IX_KT_KursMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats",
                column: "UT_KGRMufredatId");

            migrationBuilder.AddForeignKey(
                name: "FK_KT_KursMufredats_UT_KGRMufredats_UT_KGRMufredatId",
                table: "KT_KursMufredats",
                column: "UT_KGRMufredatId",
                principalTable: "UT_KGRMufredats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KGRMufredats_UT_KursGunlukRapors_UT_KursGunlukRaporId",
                table: "UT_KGRMufredats",
                column: "UT_KursGunlukRaporId",
                principalTable: "UT_KursGunlukRapors",
                principalColumn: "Id");
        }
    }
}
