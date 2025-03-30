using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;

namespace BookSeries.Application.Services.Implementation
{
    public class OrderDetailService : IOrderDetailRepository
    {
        public Task AddAsync(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetByBooKIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderStatus(int bookId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
