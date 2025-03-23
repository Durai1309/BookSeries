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

        public async Task<IActionResult> CreateBook()
        {
            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (book != null)
            {
                if (book.Image != null)
                {
                    string fileExtension = Path.GetExtension(book.Image.FileName).ToLower();
                    string fileName = Guid.NewGuid() + fileExtension;
                    string filePath = Path.Combine("wwwroot", "ProductImages", fileName);

                    string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProductImages");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        await book.Image.CopyToAsync(fileStream);
                    }

                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.PathBase}";
                    book.ImageUrl = baseUrl + "/ProductImages/" + fileName;
                    book.ImageLocalPath = filePath;
                }
                else
                {
                    book.ImageUrl = "https://placehold.co/600x400";
                }

                await _bookService.AddBookAsync(book);
                return RedirectToAction(nameof(BookIndex));
            }

            var bookSeriesListForError = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesListForError;

            return View(book);
        }


        public async Task<IActionResult> BookIndex()
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

        public async Task<IActionResult> EditBook(int id)
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
        public async Task<IActionResult> EditBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (id != null)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction(nameof(BookIndex), new { bookCollectionId = book.BookSeriesId });
            }

            var bookSeriesList = await _bookCollectionService.GetAllBookCollectionsAsync();
            ViewData["BookSeries"] = bookSeriesList;

            return View(book);
        }

        public async Task<IActionResult> DeleteBook(int id)
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
            return RedirectToAction(nameof(BookIndex));
        }
    }
}