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

//public async Task SeedBookSeriesData()
//{
//    // Check if the BookSeries already exists to avoid duplicates
//    if (!_context.BookSeries.Any())
//    {
//        var bookSeries = new BookCollection
//        {
//            Title = "The Great Fantasy Series",
//            Description = "An epic fantasy series following the adventures of a hero.",
//            CreatedDate = DateTime.Now,
//            Books = new List<Book>
//        {
//            new Book
//            {
//                Title = "The Beginning",
//                Author = "John Doe",
//                Order = 1
//            },
//            new Book
//            {
//                Title = "The Adventure Continues",
//                Author = "John Doe",
//                Order = 2
//            },
//            new Book
//            {
//                Title = "The Final Chapter",
//                Author = "John Doe",
//                Order = 3
//            }
//        }
//        };
//    }