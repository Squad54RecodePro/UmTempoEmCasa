using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmTempoEmCasa.Migrations
{
    public partial class comnomeimagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nomeimagem",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nomeimagem",
                table: "Anuncios");
        }
    }
}
