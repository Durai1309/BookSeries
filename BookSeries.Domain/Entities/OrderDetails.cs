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
        public List<Book> Books { get; set; }
    }
}
