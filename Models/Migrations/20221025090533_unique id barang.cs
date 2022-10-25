using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class uniqueidbarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs",
                column: "IdBarang",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs",
                column: "IdBarang");
        }
    }
}
