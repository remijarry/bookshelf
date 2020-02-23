using System;
using System.Collections.Generic;

namespace Library.API.Models
{
    public class Book : BaseEntity
    {
        public IEnumerable<BookshelfBook> BookshelveBooks { get; set; } = new List<BookshelfBook>();

        public IEnumerable<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public Genre Genre { get; set; }

        public string Title { get; set; }

        public Review Review { get; set; }

        public string Synopsis { get; set; }

        public string Editor { get; set; }

        public int Length { get; set; }

        public bool ToRead { get; set; }

        public bool HaveRead { get; set; }

        public bool Favorite { get; set; }

        public bool Reading { get; set; }

        public DateTime DateFinished { get; set; }

        public DateTime DateStarted { get; set; }
    }
}