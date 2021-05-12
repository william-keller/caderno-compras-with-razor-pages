using Microsoft.EntityFrameworkCore.Migrations;

namespace RIEG.Compras.Caderno.Data.Migrations
{
    public partial class Categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Category");
        }
    }
}
