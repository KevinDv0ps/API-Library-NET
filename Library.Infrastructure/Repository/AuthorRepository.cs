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
    public class AuthorRepository: IAuthorRepository
    {
        private readonly DataContextLibrary dataContextLibrary;
        public AuthorRepository(DataContextLibrary context)
        {
            dataContextLibrary = context;
        }

        public async Task AddAsync(Author author)
        {
            dataContextLibrary.Authors.Add(author);
            await dataContextLibrary.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await dataContextLibrary.Authors.ToListAsync();
        }

        public async Task<Author?> GetAsyncById(int id_author)
        {
            return await dataContextLibrary.Authors.FindAsync(id_author);
        }

        public async Task<Author?> SearchByNameAsync(string name)
        {
            return await dataContextLibrary.Authors.Where(d => d.first_name == name).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            dataContextLibrary.Authors.Update(author);
            await dataContextLibrary.SaveChangesAsync();
        }
    }
}
