using BookSeries.Domain.Entities;

namespace BookSeries.Web.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new();
        public double OrderTotal => OrderItems.Sum(oi => oi.Price * oi.Count);
    }

    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
