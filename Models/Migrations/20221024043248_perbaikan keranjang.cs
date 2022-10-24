using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class perbaikankeranjang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTransaksis_transaksis_IdTransaksi",
                table: "ItemTransaksis");

            migrationBuilder.DropForeignKey(
                name: "FK_transaksis_Users_IdUser",
                table: "transaksis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaksis",
                table: "transaksis");

            migrationBuilder.RenameTable(
                name: "transaksis",
                newName: "Transaksis");

            migrationBuilder.RenameIndex(
                name: "IX_transaksis_IdUser",
                table: "Transaksis",
                newName: "IX_Transaksis_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaksis",
                table: "Transaksis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTransaksis_Transaksis_IdTransaksi",
                table: "ItemTransaksis",
                column: "IdTransaksi",
                principalTable: "Transaksis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksis_Users_IdUser",
                table: "Transaksis",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTransaksis_Transaksis_IdTransaksi",
                table: "ItemTransaksis");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaksis_Users_IdUser",
                table: "Transaksis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaksis",
                table: "Transaksis");

            migrationBuilder.RenameTable(
                name: "Transaksis",
                newName: "transaksis");

            migrationBuilder.RenameIndex(
                name: "IX_Transaksis_IdUser",
                table: "transaksis",
                newName: "IX_transaksis_IdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaksis",
                table: "transaksis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTransaksis_transaksis_IdTransaksi",
                table: "ItemTransaksis",
                column: "IdTransaksi",
                principalTable: "transaksis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaksis_Users_IdUser",
                table: "transaksis",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
