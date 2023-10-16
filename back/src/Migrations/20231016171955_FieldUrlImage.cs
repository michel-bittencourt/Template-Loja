using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.API.Migrations
{
    public partial class FieldUrlImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Products");
        }
    }
}
