using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class HaftalikDegerlendirmeRaporuGozlem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursHaftalıkDegerlendirmeRaporus_UT_Kurs_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_KursHaftalıkDegerlendirmeRaporus",
                table: "UT_KursHaftalıkDegerlendirmeRaporus");

            migrationBuilder.RenameTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporus",
                newName: "UT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursHaftalıkDegerlendirmeRaporus_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporu",
                newName: "IX_UT_KursHaftalıkDegerlendirmeRaporu_KursId");

            migrationBuilder.AddColumn<int>(
                name: "Hafta",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_KursHaftalıkDegerlendirmeRaporu",
                table: "UT_KursHaftalıkDegerlendirmeRaporu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "KursId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporu_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId",
                principalTable: "UT_KursHaftalıkDegerlendirmeRaporu",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_Kurs_KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursHaftalıkDegerlendirmeRaporu_UT_Kurs_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporu",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporu_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_Kurs_KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursHaftalıkDegerlendirmeRaporu_UT_Kurs_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.DropIndex(
                name: "IX_UT_HaftalıkDegerlendirmeRaporuGozlemlers_KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_KursHaftalıkDegerlendirmeRaporu",
                table: "UT_KursHaftalıkDegerlendirmeRaporu");

            migrationBuilder.DropColumn(
                name: "Hafta",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.DropColumn(
                name: "KursId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers");

            migrationBuilder.RenameTable(
                name: "UT_KursHaftalıkDegerlendirmeRaporu",
                newName: "UT_KursHaftalıkDegerlendirmeRaporus");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursHaftalıkDegerlendirmeRaporu_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporus",
                newName: "IX_UT_KursHaftalıkDegerlendirmeRaporus_KursId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_KursHaftalıkDegerlendirmeRaporus",
                table: "UT_KursHaftalıkDegerlendirmeRaporus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_HaftalıkDegerlendirmeRaporuGozlemlers_UT_KursHaftalıkDegerlendirmeRaporus_HaftalikDegerlendirmeRaporuId",
                table: "UT_HaftalıkDegerlendirmeRaporuGozlemlers",
                column: "HaftalikDegerlendirmeRaporuId",
                principalTable: "UT_KursHaftalıkDegerlendirmeRaporus",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursHaftalıkDegerlendirmeRaporus_UT_Kurs_KursId",
                table: "UT_KursHaftalıkDegerlendirmeRaporus",
                column: "KursId",
                principalTable: "UT_Kurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
