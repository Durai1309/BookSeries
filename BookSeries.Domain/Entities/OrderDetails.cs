using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeries.Domain.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double Price { get; set; }
        public int Count { get; set; }
        public string? UserId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }

}
