using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class transaksidankeranjang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keranjangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdBarang = table.Column<int>(type: "integer", nullable: false),
                    HargaSatuan = table.Column<decimal>(type: "numeric", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Jumlah = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keranjangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keranjangs_Barangs_IdBarang",
                        column: x => x.IdBarang,
                        principalTable: "Barangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Keranjangs_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaksis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    TotalHarga = table.Column<decimal>(type: "numeric", nullable: false),
                    MetodePembayaran = table.Column<string>(type: "text", nullable: false),
                    StatusTransaksi = table.Column<string>(type: "text", nullable: false),
                    StatusBayar = table.Column<string>(type: "text", nullable: false),
                    AlamatPengiriman = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaksis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transaksis_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTransaksis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdBarang = table.Column<int>(type: "integer", nullable: false),
                    Harga = table.Column<decimal>(type: "numeric", nullable: false),
                    Jumlah = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    IdTransaksi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTransaksis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTransaksis_Barangs_IdBarang",
                        column: x => x.IdBarang,
                        principalTable: "Barangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTransaksis_transaksis_IdTransaksi",
                        column: x => x.IdTransaksi,
                        principalTable: "transaksis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTransaksis_IdBarang",
                table: "ItemTransaksis",
                column: "IdBarang");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTransaksis_IdTransaksi",
                table: "ItemTransaksis",
                column: "IdTransaksi");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdBarang",
                table: "Keranjangs",
                column: "IdBarang");

            migrationBuilder.CreateIndex(
                name: "IX_Keranjangs_IdUser",
                table: "Keranjangs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_transaksis_IdUser",
                table: "transaksis",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTransaksis");

            migrationBuilder.DropTable(
                name: "Keranjangs");

            migrationBuilder.DropTable(
                name: "transaksis");
        }
    }
}
