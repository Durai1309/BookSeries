﻿using BookSeries.Application.Services.Interface;
using BookSeries.Domain.Entities;
using BookSeries.Infrastructure.Data;
using BookSeries.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BookSeries.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Book> GetByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.BookSeries).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Domain.Entities.Book>> GetByBookCollectionIdAsync(int bookCollectionId)
        {
            return await _context.Books
                                 .Where(b => b.BookSeriesId == bookCollectionId)
                                 .Include(b => b.BookSeries)
                                 .ToListAsync();
        }

        public async Task AddAsync(Domain.Entities.Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Domain.Entities.Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync(); 
        }
    }

}
