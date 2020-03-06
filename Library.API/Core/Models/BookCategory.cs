namespace Library.API.Core.Models
{
    public class BookCategory
    {
        public Book Book { get; set; }
        public int BookId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}