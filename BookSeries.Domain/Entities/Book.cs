using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeries.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int BookSeriesId { get; set; }
        public BookCollection BookSeries { get; set; }
        public int Order { get; set; }
    }
}
