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
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContextLibrary dataContextLibrary;
        public GenreRepository(DataContextLibrary context)
        {
            dataContextLibrary = context;
        }
        public async Task AddAsync(Genre genre)
        {
            dataContextLibrary.Genres.Add(genre);
            await dataContextLibrary.SaveChangesAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await dataContextLibrary.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByidAsync(int id_genre)
        {
            return await dataContextLibrary.Genres.FindAsync(id_genre);
        }

        public async Task<Genre?> GetByNameAsync(string name)
        {
            return await dataContextLibrary.Genres.FirstOrDefaultAsync(a => a.genre_name == name);
        }

        public async Task UpdateAsync(Genre genre)
        {
            dataContextLibrary.Genres.Update(genre);
            await dataContextLibrary.SaveChangesAsync();
        }
    }
}
