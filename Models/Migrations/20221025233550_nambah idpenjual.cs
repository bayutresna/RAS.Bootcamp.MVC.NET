using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class nambahidpenjual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPenjual",
                table: "Transaksis",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPenjual",
                table: "Transaksis");
        }
    }
}
