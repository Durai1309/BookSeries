using BookSeries.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeries.Application.Services.Interface
{
    public interface IOrderDetailRepository
    {
        Task AddAsync(OrderDetails orderDetails);
        Task<List<Book>> GetByBooKIdAsync(int bookId);
        Task<List<Book>> GetAllAsync();
        Task UpdateOrderStatus(int bookId , string newStatus);
    }
}
