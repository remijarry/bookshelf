using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class Booksynopsisdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
