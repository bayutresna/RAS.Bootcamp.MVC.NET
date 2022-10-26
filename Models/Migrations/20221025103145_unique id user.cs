using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class uniqueiduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdBarang_IdUser",
                table: "Keranjangs",
                columns: new[] { "IdBarang", "IdUser" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keranjangs_IdBarang_IdUser",
                table: "Keranjangs");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs",
                column: "IdBarang",
                unique: true);
        }
    }
}
