﻿using BookSeries.Domain.Entities;
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
        Task<Book> GetByBookIdAsync(int bookId);
        Task<List<OrderDetails>> GetAllAsync();
        Task UpdateOrderStatus(int bookId , string newStatus);
        Task<OrderDetails> GetByOrderIdAsync(int orderId);
    }
}
