using BookSeries.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSeries.Application.Services.Interface
{
    public interface IBookCollectionRepository
    {
        Task<BookCollection> GetByIdAsync(int id);
        Task<List<BookCollection>> GetAllAsync();
        Task AddAsync(BookCollection bookCollection);
        Task UpdateAsync(BookCollection bookCollection);
        Task DeleteAsync(int id);
    }
}
