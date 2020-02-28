using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class BookAddedGoogleBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleBookId",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleBookId",
                table: "Books");
        }
    }
}
