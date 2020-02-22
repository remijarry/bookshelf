namespace Library.API.models
{
    public class BookshelfBook
    {
        public int BookshelfId { get; set; }
        public Bookshelf Bookshelf { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}