using BookSeries.Application.Services.Implementation;
using BookSeries.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookSeries.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly BookCollectionService _bookCollectionService; 

        public BookController(BookService bookService, BookCollectionService bookCollectionService)
        {
            _bookService = bookService;
            _bookCollectionService = bookCollectionService;
        }

        public async Task<IActionResult> Create()
        {
            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (book != null)
            {
                await _bookService.AddBookAsync(book);
                return RedirectToAction(nameof(Index));
            }

            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View(book);
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync(); 
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBooksByCollectionIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book); 
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBooksByCollectionIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction(nameof(Index), new { bookCollectionId = book.BookSeriesId });
            }
            return View(book); 
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBooksByCollectionIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}