using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.InterfaceRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id_user);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        // Busca un usuario por su nombre de usuario o email para validar login.
        Task<User?> GetByEmailAsync(string mail);
    }
}
