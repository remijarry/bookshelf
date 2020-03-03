using System.Collections.Generic;

namespace Library.API.DTOs
{
    public class BookDto
    {
        // Consider using Data Annotations to add [Required] and [MaxLength] etc to support model validation
        // [ApiController] does model validation for you automatically; you just need to inform it how to check things
        public int UserId { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; } // initialize here to avoid null reference errors

        public string Publisher { get; set; }

        public string ImageLink { get; set; }

        public string Description { get; set; }

        public int BookshelfId { get; set; }

        public string GoogleBookId { get; set; }

        public List<string> Categories { get; set; } // initialize here to avoid null reference errors

        public int PageCount { get; set; }
    }
}
