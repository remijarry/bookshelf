using System.Collections.Generic;

namespace Library.API.DTOs
{
    public class BookDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public int BookshelfId { get; set; }

        public string GoogleBookId { get; set; }

        public List<string> Categories { get; set; }

        public int PageCount { get; set; }
    }
}
