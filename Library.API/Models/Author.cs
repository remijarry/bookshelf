using System.Collections.Generic;

namespace Library.API.Models
{
    public class Author : BaseEntity
    {
        public IEnumerable<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}