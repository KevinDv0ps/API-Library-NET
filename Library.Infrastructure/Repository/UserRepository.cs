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
    public class UserRepository: IUserRepository
    {
        private readonly DataContextLibrary dataContextLibrary;
        public UserRepository(DataContextLibrary context)
        {
            dataContextLibrary = context;
        }
        public async Task CreateAsync(User user)
        {
            dataContextLibrary.Users.Add(user);
            await dataContextLibrary.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await dataContextLibrary.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string mail)
        {
            return await dataContextLibrary.Users.FirstOrDefaultAsync(d => d.email == mail);
        }

        public async Task<User?> GetByIdAsync(int id_user)
        {
            return await dataContextLibrary.Users.FindAsync(id_user);
        }

        public async Task UpdateAsync(User user)
        {
            dataContextLibrary.Users.Update(user);
            await dataContextLibrary.SaveChangesAsync();
        }
    }
}
