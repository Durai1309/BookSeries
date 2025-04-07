using BookSeries.Application.Services.Implementation;
using BookSeries.Domain.Entities;
using BookSeries.Web.Models;
using BookSeries.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace BookSeries.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly OrderDetailService _orderDetailService;

        public OrderController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public IActionResult OrderIndex()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Detail(int bookId)
        {
            var book = await _orderDetailService.GetByBookIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var order = await _orderDetailService.GetByOrderIdAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Book bookDetails)
        {
            var orderDetails = new OrderDetails
            {
                BookId = bookDetails.Id,
                Book = bookDetails,
                Price = bookDetails.Price,
                Count = bookDetails.Count
            };

            return View(orderDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirmation(OrderDetails orderDetails)
        {
            string userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            orderDetails.OrderDate = DateTime.Now;
            orderDetails.Status = "Pending";
            orderDetails.UserId = userId;
            await _orderDetailService.AddAsync(orderDetails);
            return View();
        }
        public async Task<IActionResult> ApprovedOrder(int orderId)
        {
            return View();
        }

        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            return View();
        }

        public async Task<IActionResult> CancelOrder(int orderId)
        {
            return View();
        }
        
        public async Task<IActionResult> ReadyforPickup(int orderId)
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderDetailService.GetAllAsync();
            return View(response);
        }
    }
}
