namespace BookSeries.Domain.Entities
{
    public class BookCollection
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedDate { get; set; } 

        public List<Book> Books { get; set; } 
    }
}
