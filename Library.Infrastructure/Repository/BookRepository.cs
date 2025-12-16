using Library.Application.Interfaces.InterfaceRepository;
using Library.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContextLibrary dataContextLibrary;
        public BookRepository(DataContextLibrary context)
        {
            dataContextLibrary = context;
        }

        public async Task AddAsync(Book book)
        {
            dataContextLibrary.Books.Add(book);
            await dataContextLibrary.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            dataContextLibrary.Remove(book);
            await dataContextLibrary.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(int id_author)
        {
            return await dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Where(d => d.Authors.Any(a => a.id == id_author))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetByGenreAsync(int id_genre)
        {
            return await dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .Where(d => d.Genres.Any(a => a.id == id_genre))
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id_book)
        {
            return await dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(b => b.id == id_book);
        }
        public async Task<Book?> SearchByNameAsync(string name)
        {
            return await dataContextLibrary.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(a => a.title == name);
        }

        public async Task UpdateAsync(Book book)
        {
            dataContextLibrary.Books.Update(book);
            await dataContextLibrary.SaveChangesAsync();

        }
    }
}
