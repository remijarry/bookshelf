using System.Collections.Generic;
using System.Linq;

namespace Library.API.models
{
    public class Bookshelf : BaseEntity
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public List<BookshelfBook> Books { get; private set; } = new List<BookshelfBook>();

        public void AddBook(Book book)
        {
            if (!Books.Any(b => b.BookId == book.Id))
            {
                Books.Add(new BookshelfBook { Book = book });
                return;
            }
        }

        public void RemoveBook(int bookId)
        {
            var book = Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                Books.Remove(book);
            }
        }

    }
}