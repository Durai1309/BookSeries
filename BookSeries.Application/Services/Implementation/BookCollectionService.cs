using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;

namespace BookSeries.Application.Services.Implementation
{
    public class BookCollectionService
    {
        private readonly IBookCollectionRepository _bookCollectionRepository;

        public BookCollectionService(IBookCollectionRepository bookCollectionRepository)
        {
            _bookCollectionRepository = bookCollectionRepository;
        }

        public async Task<BookCollection> GetBookCollectionByIdAsync(int id)
        {
            return await _bookCollectionRepository.GetByIdAsync(id);
        }

        public async Task<List<BookCollection>> GetAllBookCollectionsAsync()
        {
            return await _bookCollectionRepository.GetAllAsync();
        }

        public async Task AddBookCollectionAsync(BookCollection bookCollection)
        {
            if (bookCollection == null)
                throw new ArgumentNullException(nameof(bookCollection));

            await _bookCollectionRepository.AddAsync(bookCollection);
        }

        public async Task UpdateBookCollectionAsync(BookCollection bookCollection)
        {
            if (bookCollection == null)
                throw new ArgumentNullException(nameof(bookCollection));

            await _bookCollectionRepository.UpdateAsync(bookCollection);
        }

        public async Task DeleteBookCollectionAsync(int id)
        {
            await _bookCollectionRepository.DeleteAsync(id);
        }
    }
}
