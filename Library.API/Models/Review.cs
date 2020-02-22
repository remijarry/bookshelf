namespace Library.API.models
{
    public class Review : BaseEntity
    {
        public double Rate { get; set; }

        public string Comment { get; set; }
    }
}