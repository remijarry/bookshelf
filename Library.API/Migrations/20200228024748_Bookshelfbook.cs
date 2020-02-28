using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class Bookshelfbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBook_Books_BookId",
                table: "BookshelfBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBook_Bookshelves_BookshelfId",
                table: "BookshelfBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookshelfBook",
                table: "BookshelfBook");

            migrationBuilder.RenameTable(
                name: "BookshelfBook",
                newName: "BookshelfBooks");

            migrationBuilder.RenameIndex(
                name: "IX_BookshelfBook_BookshelfId",
                table: "BookshelfBooks",
                newName: "IX_BookshelfBooks_BookshelfId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookshelfBooks",
                table: "BookshelfBooks",
                columns: new[] { "BookId", "BookshelfId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBooks_Books_BookId",
                table: "BookshelfBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBooks_Bookshelves_BookshelfId",
                table: "BookshelfBooks",
                column: "BookshelfId",
                principalTable: "Bookshelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBooks_Books_BookId",
                table: "BookshelfBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfBooks_Bookshelves_BookshelfId",
                table: "BookshelfBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookshelfBooks",
                table: "BookshelfBooks");

            migrationBuilder.RenameTable(
                name: "BookshelfBooks",
                newName: "BookshelfBook");

            migrationBuilder.RenameIndex(
                name: "IX_BookshelfBooks_BookshelfId",
                table: "BookshelfBook",
                newName: "IX_BookshelfBook_BookshelfId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookshelfBook",
                table: "BookshelfBook",
                columns: new[] { "BookId", "BookshelfId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBook_Books_BookId",
                table: "BookshelfBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfBook_Bookshelves_BookshelfId",
                table: "BookshelfBook",
                column: "BookshelfId",
                principalTable: "Bookshelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
