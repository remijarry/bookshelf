using System.Collections.Generic;

namespace Library.API.models
{
    public class Author : BaseEntity
    {
        public IEnumerable<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}