using System.Collections.Generic;

namespace Library.API.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<BookCategory> Books { get; set; }
    }
}