using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmTempoEmCasa.Migrations
{
    public partial class nomeanuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeAnuncio",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeAnuncio",
                table: "Anuncios");
        }
    }
}
