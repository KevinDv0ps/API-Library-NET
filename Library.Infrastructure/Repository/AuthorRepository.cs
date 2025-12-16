using Library.Application.Interfaces.InterfaceRepository;
using Library.Entities;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<IEnumerable<Author?>> SearchByNameAsync(string[] name)
        {
            return await dataContextLibrary.Authors
                .Where(author =>
                    name.All(p =>
                        author.first_name.ToLower().Contains(p) ||
                        (author.second_name != null && author.second_name.ToLower().Contains(p)) ||
                        author.first_lastname.ToLower().Contains(p) ||
                        (author.second_lastname != null && author.second_lastname.ToLower().Contains(p))
                    )
                )
                .ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            dataContextLibrary.Authors.Update(author);
            await dataContextLibrary.SaveChangesAsync();
        }

    }
}
