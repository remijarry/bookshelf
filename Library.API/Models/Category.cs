using System.Collections.Generic;

namespace Library.API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<BookCategory> Books { get; set; }
    }
}