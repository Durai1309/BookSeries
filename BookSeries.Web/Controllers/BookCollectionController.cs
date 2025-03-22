using BookSeries.Application.Services.Implementation;
using BookSeries.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookSeries.Web.Controllers
{
    public class BookCollectionController : Controller
    {
        private readonly BookCollectionService _bookCollectionService;

        public BookCollectionController(BookCollectionService bookCollectionService)
        {
            _bookCollectionService = bookCollectionService;
        }

        public async Task<IActionResult> Index()
        {
            var bookCollections = await _bookCollectionService.GetAllBookCollectionsAsync();
            return View(bookCollections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bookCollection = await _bookCollectionService.GetBookCollectionByIdAsync(id);
            if (bookCollection == null)
            {
                return NotFound();
            }
            return View(bookCollection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCollection bookCollection)
        {
            if (bookCollection != null)
            {
                await _bookCollectionService.AddBookCollectionAsync(bookCollection);
                return RedirectToAction(nameof(Index));
            }
                return View(bookCollection);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bookCollection = await _bookCollectionService.GetBookCollectionByIdAsync(id);
            if (bookCollection == null)
            {
                return NotFound();
            }
            return View(bookCollection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookCollection bookCollection)
        {
            if (id != bookCollection.Id)
            {
                return BadRequest();
            }

            if (id != null)
            {
                await _bookCollectionService.UpdateBookCollectionAsync(bookCollection);
                return RedirectToAction(nameof(Index));
            }
            return View(bookCollection);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var bookCollection = await _bookCollectionService.GetBookCollectionByIdAsync(id);
            if (bookCollection == null)
            {
                return NotFound();
            }
            return View(bookCollection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookCollectionService.DeleteBookCollectionAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
