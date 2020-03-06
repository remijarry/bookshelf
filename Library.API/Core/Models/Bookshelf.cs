using System.Collections.Generic;
using System.Linq;

namespace Library.API.Core.Models
{
    public class Bookshelf : BaseEntity
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        private readonly List<BookshelfBook> _books = new List<BookshelfBook>();

        public IEnumerable<BookshelfBook> Books => _books.AsReadOnly();

        public void AddBook(Book book)
        {
            _books.Add(new BookshelfBook { Book = book });
            return;
        }

        public void RemoveBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

    }
}