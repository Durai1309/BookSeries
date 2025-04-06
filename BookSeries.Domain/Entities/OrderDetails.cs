using System.ComponentModel.DataAnnotations;

namespace BookSeries.Domain.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        public string? Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime OrderDate { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
