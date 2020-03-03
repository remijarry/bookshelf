using System.Collections.Generic;

namespace Library.API.Models // probably could move this under Core.Model or Core.Entities
{
    public class Author : BaseEntity
    {
        public IEnumerable<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public string Name { get; set; }
    }
}