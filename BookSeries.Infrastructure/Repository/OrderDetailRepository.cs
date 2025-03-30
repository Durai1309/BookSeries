using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;
using BookSeries.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSeries.Infrastructure.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetByBooKIdAsync(int bookId)
        {
            return await _context.Books.Where(b => b.Id == bookId).ToListAsync();
        }

        public Task UpdateOrderStatus(int bookId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
