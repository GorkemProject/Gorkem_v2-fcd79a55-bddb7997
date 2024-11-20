using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class addKursiyerToKurs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_UT_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropIndex(
                name: "IX_UT_Kursiyer_UT_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.DropColumn(
                name: "UT_KursId",
                table: "UT_Kursiyer");

            migrationBuilder.CreateTable(
                name: "UT_KursUT_Kursiyer",
                columns: table => new
                {
                    KursiyerlerId = table.Column<int>(type: "int", nullable: false),
                    KurslarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UT_KursUT_Kursiyer", x => new { x.KursiyerlerId, x.KurslarId });
                    table.ForeignKey(
                        name: "FK_UT_KursUT_Kursiyer_UT_Kurs_KurslarId",
                        column: x => x.KurslarId,
                        principalTable: "UT_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UT_KursUT_Kursiyer_UT_Kursiyer_KursiyerlerId",
                        column: x => x.KursiyerlerId,
                        principalTable: "UT_Kursiyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursUT_Kursiyer_KurslarId",
                table: "UT_KursUT_Kursiyer",
                column: "KurslarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UT_KursUT_Kursiyer");

            migrationBuilder.AddColumn<int>(
                name: "UT_KursId",
                table: "UT_Kursiyer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UT_Kursiyer_UT_KursId",
                table: "UT_Kursiyer",
                column: "UT_KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_Kursiyer_UT_Kurs_UT_KursId",
                table: "UT_Kursiyer",
                column: "UT_KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id");
        }
    }
}
