using System.Collections.Generic;

namespace Library.API.Core.Models
{
    public class Author : BaseEntity
    {
        public IEnumerable<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public string Name { get; set; }
    }
}