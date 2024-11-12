using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gorkem_.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCalKad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_BirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "EvrakAtama",
                table: "UT_KopekCalKads");

            migrationBuilder.RenameColumn(
                name: "BirimId",
                table: "UT_KopekCalKads",
                newName: "FiiliBirimId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KopekCalKads_BirimId",
                table: "UT_KopekCalKads",
                newName: "IX_UT_KopekCalKads_FiiliBirimId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "T_IlisikKesme",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "T_GoreveBaslama",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "KopekId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "T_EvrakAtama",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_FiiliBirimId",
                table: "UT_KopekCalKads",
                column: "FiiliBirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekCalKads",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_FiiliBirimId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropForeignKey(
                name: "FK_UT_KopekCalKads_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekCalKads");

            migrationBuilder.DropColumn(
                name: "T_EvrakAtama",
                table: "UT_KopekCalKads");

            migrationBuilder.RenameColumn(
                name: "FiiliBirimId",
                table: "UT_KopekCalKads",
                newName: "BirimId");

            migrationBuilder.RenameIndex(
                name: "IX_UT_KopekCalKads_FiiliBirimId",
                table: "UT_KopekCalKads",
                newName: "IX_UT_KopekCalKads_BirimId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "T_IlisikKesme",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "T_GoreveBaslama",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KopekId",
                table: "UT_KopekCalKads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EvrakAtama",
                table: "UT_KopekCalKads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_KT_FiiliBirims_BirimId",
                table: "UT_KopekCalKads",
                column: "BirimId",
                principalTable: "KT_FiiliBirims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UT_KopekCalKads_UT_Kopek_Kopeks_KopekId",
                table: "UT_KopekCalKads",
                column: "KopekId",
                principalTable: "UT_Kopek_Kopeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
