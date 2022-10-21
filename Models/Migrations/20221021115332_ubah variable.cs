using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAS.Bootcamp.MVC.NET.Models.Migrations
{
    public partial class ubahvariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Alamat",
                table: "Penjuals",
                newName: "NoHP");

            migrationBuilder.AddColumn<string>(
                name: "AlamatToko",
                table: "Penjuals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoHP",
                table: "Pembelis",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "url",
                table: "Barangs",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "imgname",
                table: "Barangs",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlamatToko",
                table: "Penjuals");

            migrationBuilder.DropColumn(
                name: "NoHP",
                table: "Pembelis");

            migrationBuilder.RenameColumn(
                name: "NoHP",
                table: "Penjuals",
                newName: "Alamat");

            migrationBuilder.AlterColumn<string>(
                name: "url",
                table: "Barangs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "imgname",
                table: "Barangs",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);
        }
    }
}
