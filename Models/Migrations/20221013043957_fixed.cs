using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class @fixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barangs_Penjuals_PenjualId",
                table: "Barangs");

            migrationBuilder.DropIndex(
                name: "IX_Barangs_PenjualId",
                table: "Barangs");

            migrationBuilder.DropColumn(
                name: "PenjualId",
                table: "Barangs");

            migrationBuilder.CreateTable(
                name: "Pembelis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    NamaPembeli = table.Column<string>(type: "text", nullable: true),
                    AlamatPembeli = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembelis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pembelis_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barangs_IdPenjual",
                table: "Barangs",
                column: "IdPenjual");

            migrationBuilder.CreateIndex(
                name: "IX_Pembelis_IdUser",
                table: "Pembelis",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Barangs_Penjuals_IdPenjual",
                table: "Barangs",
                column: "IdPenjual",
                principalTable: "Penjuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barangs_Penjuals_IdPenjual",
                table: "Barangs");

            migrationBuilder.DropTable(
                name: "Pembelis");

            migrationBuilder.DropIndex(
                name: "IX_Barangs_IdPenjual",
                table: "Barangs");

            migrationBuilder.AddColumn<int>(
                name: "PenjualId",
                table: "Barangs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barangs_PenjualId",
                table: "Barangs",
                column: "PenjualId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barangs_Penjuals_PenjualId",
                table: "Barangs",
                column: "PenjualId",
                principalTable: "Penjuals",
                principalColumn: "Id");
        }
    }
}
