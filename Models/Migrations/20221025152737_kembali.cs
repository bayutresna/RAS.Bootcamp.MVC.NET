using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class kembali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaksis_Users_UserId",
                table: "Transaksis");

            migrationBuilder.DropColumn(
                name: "IdPembeli",
                table: "Transaksis");

            migrationBuilder.DropColumn(
                name: "IdPenjual",
                table: "Transaksis");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transaksis",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Transaksis_UserId",
                table: "Transaksis",
                newName: "IX_Transaksis_IdUser");

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
                name: "FK_Transaksis_Users_IdUser",
                table: "Transaksis");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Transaksis",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaksis_IdUser",
                table: "Transaksis",
                newName: "IX_Transaksis_UserId");

            migrationBuilder.AddColumn<int>(
                name: "IdPembeli",
                table: "Transaksis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPenjual",
                table: "Transaksis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksis_Users_UserId",
                table: "Transaksis",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
