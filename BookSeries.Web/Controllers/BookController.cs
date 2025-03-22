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
                if (book.Image != null)
                {

                    string fileName = book.Id + Path.GetExtension(book.Image.FileName);
                    string filePath = @"wwwroot\ProductImages\" + fileName;

                    //I have added the if condition to remove the any image with same name if that exist in the folder by any change
                    var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    FileInfo file = new FileInfo(directoryLocation);
                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        book.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    book.ImageUrl = baseUrl + "/ProductImages/" + fileName;
                    book.ImageLocalPath = filePath;
                }
                else
                {
                    book.ImageUrl = "https://placehold.co/600x400";
                }
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
            var book = await _bookService.GetByAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (id != null)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction(nameof(Index), new { bookCollectionId = book.BookSeriesId });
            }

            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}