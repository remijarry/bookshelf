using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class BookModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favourite",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "HaveRead",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Reading",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ToRead",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "Favourite",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HaveRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reading",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ToRead",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
