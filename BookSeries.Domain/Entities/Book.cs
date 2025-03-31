using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double Price { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        [NotMapped]
        public int Count { get; set; }
    }

}
