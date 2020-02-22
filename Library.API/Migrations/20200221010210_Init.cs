using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookshelves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookshelves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ReviewId = table.Column<int>(nullable: true),
                    Synopsis = table.Column<string>(nullable: true),
                    Editor = table.Column<string>(nullable: true),
                    Length = table.Column<int>(nullable: false),
                    ToRead = table.Column<bool>(nullable: false),
                    HaveRead = table.Column<bool>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false),
                    Reading = table.Column<bool>(nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Books_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Authors_BookId",
                        column: x => x.BookId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookshelfBook",
                columns: table => new
                {
                    BookshelfId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookshelfBook", x => new { x.BookId, x.BookshelfId });
                    table.ForeignKey(
                        name: "FK_BookshelfBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookshelfBook_Bookshelves_BookshelfId",
                        column: x => x.BookshelfId,
                        principalTable: "Bookshelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Aurélien", "Barrau" },
                    { 2, "Hugo", "Clément" },
                    { 3, "Paul", "Dubois" },
                    { 4, "Florian", "Zeller" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "DateFinished", "DateStarted", "Editor", "Favorite", "GenreId", "HaveRead", "Length", "Reading", "ReviewId", "Synopsis", "Title", "ToRead" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editions de l'Olivier", false, null, true, 233, false, null, null, "Tous les hommes n'habitent pas le monde de la même façon", false },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le Seuil", false, null, false, 180, true, null, null, "Comment j'ai arrêté de manger les animaux", false },
                    { 3, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michel Lafon", false, null, true, 143, false, null, null, "Le plus grand défi de l'histoire de l'humanité", false },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gallimard", false, null, false, 160, false, null, null, "La jouissance", true }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "Dystopia" },
                    { 8, "Detective" },
                    { 7, "Mystery" },
                    { 6, "Thriller" },
                    { 2, "Science fiction" },
                    { 4, "Western" },
                    { 3, "Horror" },
                    { 10, "Memoir" },
                    { 1, "Fantasy" },
                    { 5, "Romance" },
                    { 11, "Biography" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReviewId",
                table: "Books",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_BookshelfBook_BookshelfId",
                table: "BookshelfBook",
                column: "BookshelfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookshelfBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Bookshelves");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
