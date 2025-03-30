using BookSeries.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSeries.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int orderId)
        {
            return await Detail(orderId);
        }

        public async Task<IActionResult> Checkout()
        {
            return View();
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
