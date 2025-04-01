using BookSeries.Application.Services.Implementation;
using BookSeries.Domain.Entities;
using BookSeries.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookSeries.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly OrderDetailService _orderDetailService;

        public OrderController(OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int bookId)
        {
            var book = await _orderDetailService.GetByBookIdAsync(bookId);
            return View(book); 
        }

        public async Task<IActionResult> Checkout(Book bookDetails)
        {
             return View(bookDetails);
        }

        public async Task<IActionResult> Confirmation()
        {
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

        public IActionResult GetAll(string status)
        {
            return View();
        }
    }
}
