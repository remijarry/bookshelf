namespace Library.API.DTOs
{
    public class BookshelfForDisplayDto
    {
        public int Id { get; set; }

        public int userId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}