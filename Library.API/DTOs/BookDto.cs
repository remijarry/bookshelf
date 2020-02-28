using System.Collections.Generic;

namespace Library.API.DTOs
{
    public class BookDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }

        public List<AuthorDto> AuthorDto { get; set; }

        public string Publisher { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public int BookshelfId { get; set; }

        public string GoogleBookId { get; set; }
    }
}
