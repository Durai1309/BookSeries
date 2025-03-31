using BookSeries.Domain.Entities;

namespace BookSeries.Web.ViewModels
{
    public class BookOrderViewModel
    {
        public Book Book { get; set; }
        public int Count { get; set; }
    }
}
