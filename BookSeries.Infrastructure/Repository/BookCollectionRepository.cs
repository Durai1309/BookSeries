using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;
using BookSeries.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeries.Infrastructure.Repository
{
    public class BookCollectionRepository : IBookCollectionRepository
    {
        private readonly AppDbContext _context;

        public BookCollectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BookCollection> GetByIdAsync(int id)
        {
            return await _context.BookCollections.Include(b => b.Books).FirstOrDefaultAsync(bc => bc.Id == id);
        }

        public async Task<List<BookCollection>> GetAllAsync()
        {
            return await _context.BookCollections.Include(b => b.Books).ToListAsync();
        }

        public async Task AddAsync(BookCollection bookCollection)
        {
            await _context.BookCollections.AddAsync(bookCollection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookCollection bookCollection)
        {
            _context.BookCollections.Update(bookCollection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bookCollection = await _context.BookCollections.FindAsync(id);
            if (bookCollection != null)
            {
                _context.BookCollections.Remove(bookCollection);
                await _context.SaveChangesAsync();
            }
        }
    }
}
