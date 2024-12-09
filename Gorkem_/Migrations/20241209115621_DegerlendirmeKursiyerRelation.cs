using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class DegerlendirmeKursiyerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursrDegerlendirmeCevap_KT_KursDegerlendirmeSorular_DegerlendirmeSoruId",
                table: "UT_KursrDegerlendirmeCevap");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursrDegerlendirmeCevap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_KursrDegerlendirmeCevap",
                table: "UT_KursrDegerlendirmeCevap");

            migrationBuilder.RenameTable(
                name: "UT_KursrDegerlendirmeCevap",
                newName: "UT_KursDegerlendirmeCevap");

            migrationBuilder.RenameColumn(
                name: "DegerlendirilenVarlikId",
                table: "UT_KursDegerlendirmeCevap",
                newName: "KursiyerId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursDegerlendirmeCevap",
                newName: "IX_UT_KursDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursrDegerlendirmeCevap_DegerlendirmeSoruId",
                table: "UT_KursDegerlendirmeCevap",
                newName: "IX_UT_KursDegerlendirmeCevap_DegerlendirmeSoruId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_KursDegerlendirmeCevap",
                table: "UT_KursDegerlendirmeCevap",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UT_KursDegerlendirmeCevap_KursiyerId",
                table: "UT_KursDegerlendirmeCevap",
                column: "KursiyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_KT_KursDegerlendirmeSorular_DegerlendirmeSoruId",
                table: "UT_KursDegerlendirmeCevap",
                column: "DegerlendirmeSoruId",
                principalTable: "KT_KursDegerlendirmeSorular",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId",
                principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_UT_Kursiyer_KursiyerId",
                table: "UT_KursDegerlendirmeCevap",
                column: "KursiyerId",
                principalTable: "UT_Kursiyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_KT_KursDegerlendirmeSorular_DegerlendirmeSoruId",
                table: "UT_KursDegerlendirmeCevap");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursDegerlendirmeCevap");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KursDegerlendirmeCevap_UT_Kursiyer_KursiyerId",
                table: "UT_KursDegerlendirmeCevap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UT_KursDegerlendirmeCevap",
                table: "UT_KursDegerlendirmeCevap");

            migrationBuilder.DropIndex(
                name: "IX_UT_KursDegerlendirmeCevap_KursiyerId",
                table: "UT_KursDegerlendirmeCevap");

            migrationBuilder.RenameTable(
                name: "UT_KursDegerlendirmeCevap",
                newName: "UT_KursrDegerlendirmeCevap");

            migrationBuilder.RenameColumn(
                name: "KursiyerId",
                table: "UT_KursrDegerlendirmeCevap",
                newName: "DegerlendirilenVarlikId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursrDegerlendirmeCevap",
                newName: "IX_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormuId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KursDegerlendirmeCevap_DegerlendirmeSoruId",
                table: "UT_KursrDegerlendirmeCevap",
                newName: "IX_UT_KursrDegerlendirmeCevap_DegerlendirmeSoruId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UT_KursrDegerlendirmeCevap",
                table: "UT_KursrDegerlendirmeCevap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursrDegerlendirmeCevap_KT_KursDegerlendirmeSorular_DegerlendirmeSoruId",
                table: "UT_KursrDegerlendirmeCevap",
                column: "DegerlendirmeSoruId",
                principalTable: "KT_KursDegerlendirmeSorular",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KursrDegerlendirmeCevap_UT_KopekVeIdareciDegerlendirmeFormu_UT_KopekVeIdareciDegerlendirmeFormuId",
                table: "UT_KursrDegerlendirmeCevap",
                column: "UT_KopekVeIdareciDegerlendirmeFormuId",
                principalTable: "UT_KopekVeIdareciDegerlendirmeFormu",
                principalColumn: "Id");
        }
    }
}
