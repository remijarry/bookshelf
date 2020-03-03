using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.API.Core.Interfaces;
using Library.API.Models;

namespace Library.API.Data.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly DataContext _context;

        public BookAuthorService(DataContext context, IBookAuthorRepository bookAuthorRepository, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<List<BookAuthor>> AddAuthorsFromBook(List<string> authors, Book book)
        {
            List<Author> authorsToAdd = await GetAuthors(authors);
            foreach (var author in authorsToAdd)
            {
                book.BookAuthors.Add(new BookAuthor() { Book = book, Author = author });
            }
            await _context.SaveChangesAsync();
            return book.BookAuthors;

        }

        private async Task<List<Author>> GetAuthors(List<string> authors)
        {
            var authorsToReturn = new List<Author>();
            foreach (var authorName in authors)
            {
                var existingAuthor = await _authorRepository.ByName(authorName);
                if (existingAuthor != null)
                {
                    var newAuthor = new Author() { Name = authorName.TrimEnd() };
                    authorsToReturn.Add(newAuthor);
                }
                else
                {
                    authorsToReturn.Add(existingAuthor);
                }
            }
            return authorsToReturn;
        }
    }
}