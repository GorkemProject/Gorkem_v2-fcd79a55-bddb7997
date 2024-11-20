using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class KopekKursAddKGR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursEgitmenler_UT_Kurs_KursId",
                table: "UT_KursEgitmenler");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_KT_Birims_BirimId",
                table: "UT_Kursiyer");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_KT_Rutbes_RutbeId",
                table: "UT_Kursiyer");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_BirimId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursEgitmenler_KursId",
                table: "UT_KursEgitmenler");

            migrationBuilder.DropColumn(
                name: "AdSoyad",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "UT_KursEgitmenler");

            migrationBuilder.RenameColumn(
                name: "Sicil",
                table: "UT_Kursiyer",
                newName: "UT_KursId");

            migrationBuilder.RenameColumn(
                name: "RutbeId",
                table: "UT_Kursiyer",
                newName: "IdareciId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kursiyer_RutbeId",
                table: "UT_Kursiyer",
                newName: "IX_UT_Kursiyer_IdareciId");

            migrationBuilder.CreateTable(
                name: "UT_KursUT_KursEgitmenler",
                columns: table => new
                {
                    KursEgitmenlerId = table.Column<int>(type: "int", nullable: false),
                    KurslarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursUT_KursEgitmenler", x => new { x.KursEgitmenlerId, x.KurslarId });
                    table.ForeignKey(
                        name: "FK_UT_KursUT_KursEgitmenler_UT_KursEgitmenler_KursEgitmenlerId",
                        column: x => x.KursEgitmenlerId,
                        principalTable: "UT_KursEgitmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursUT_KursEgitmenler_UT_Kurs_KurslarId",
                        column: x => x.KurslarId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_UT_KursId",
                table: "UT_Kursiyer",
                column: "UT_KursId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursUT_KursEgitmenler_KurslarId",
                table: "UT_KursUT_KursEgitmenler",
                column: "KurslarId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer",
                column: "IdareciId",
                principalTable: "UT_Idarecis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_UT_KursId",
                table: "UT_Kursiyer",
                column: "UT_KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Idarecis_IdareciId",
                table: "UT_Kursiyer");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_UT_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropTable(
                name: "UT_KursUT_KursEgitmenler");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_UT_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.RenameColumn(
                name: "UT_KursId",
                table: "UT_Kursiyer",
                newName: "Sicil");

            migrationBuilder.RenameColumn(
                name: "IdareciId",
                table: "UT_Kursiyer",
                newName: "RutbeId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_Kursiyer_IdareciId",
                table: "UT_Kursiyer",
                newName: "IX_UT_Kursiyer_RutbeId");

            migrationBuilder.AddColumn<string>(
                name: "AdSoyad",
                table: "UT_Kursiyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "UT_KursEgitmenler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_BirimId",
                table: "UT_Kursiyer",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_KursId",
                table: "UT_Kursiyer",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursEgitmenler_KursId",
                table: "UT_KursEgitmenler",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursEgitmenler_UT_Kurs_KursId",
                table: "UT_KursEgitmenler",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_KT_Birims_BirimId",
                table: "UT_Kursiyer",
                column: "BirimId",
                principalTable: "KT_Birims",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_KT_Rutbes_RutbeId",
                table: "UT_Kursiyer",
                column: "RutbeId",
                principalTable: "KT_Rutbes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_KursId",
                table: "UT_Kursiyer",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id");
        }
    }
}
