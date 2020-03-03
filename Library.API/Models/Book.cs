using System;
using System.Collections.Generic;

namespace Library.API.Models
{
    public class Book : BaseEntity
    {
        public IEnumerable<BookshelfBook> BookshelveBooks { get; set; } = new List<BookshelfBook>();

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public List<BookCategory> Categories { get; set; } = new List<BookCategory>();

        public string Title { get; set; }

        public Review Review { get; set; }

        public string Publisher { get; set; }

        public int PageCount { get; set; }

        public DateTime DateFinished { get; set; }

        public DateTime DateStarted { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public string GoogleBookId { get; set; }
    }
}