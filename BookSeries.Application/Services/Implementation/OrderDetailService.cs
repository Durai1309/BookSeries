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

        public async Task AddAsync(OrderDetails orderDetails)
        {
            await _orderDetailRepository.AddAsync(orderDetails);
        }

        public async Task<List<OrderDetails>> GetAllAsync()
        {
            return await _orderDetailRepository.GetAllAsync();
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
