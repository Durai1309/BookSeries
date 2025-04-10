using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;
using BookSeries.Infrastructure.Data;
using BookSeries.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookSeries.Infrastructure.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.OrderDetails orderDetails)
        {
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.OrderDetails>> GetAllAsync()
        {
            var orderDetailsList = await _context.OrderDetails.ToListAsync();
            if (orderDetailsList == null)
            {
                throw new Exception("No order details found.");
            }
            return orderDetailsList;
        }


        public async Task<Domain.Entities.Book> GetByBookIdAsync(int bookId)
        {
            return await _context.Books
                                 .FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<Domain.Entities.OrderDetails> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetails.Include(o => o.Book).FirstOrDefaultAsync(b => b.Id == orderId);
        }

        public Task UpdateOrderStatus(int bookId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
