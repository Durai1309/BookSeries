using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;

namespace BookSeries.Application.Services.Implementation
{
    public class OrderDetailService 
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public Task AddAsync(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetByBookIdAsync(int bookId)
        {
            var book = await _orderDetailRepository.GetByBookIdAsync(bookId);
            return book;
        }


        public Task UpdateOrderStatus(int bookId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
