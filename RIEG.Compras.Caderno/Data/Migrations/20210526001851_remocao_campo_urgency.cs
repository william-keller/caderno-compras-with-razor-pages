using Microsoft.EntityFrameworkCore.Migrations;

namespace RIEG.Compras.Caderno.Data.Migrations
{
    public partial class remocao_campo_urgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Urgency",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Urgency",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
