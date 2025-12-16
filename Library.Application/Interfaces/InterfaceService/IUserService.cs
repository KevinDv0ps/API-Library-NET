using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;

namespace Library.Application.Interfaces.InterfaceService
{
    public interface IUserService
    {
        Task<bool> CreateAsync(UserCreateDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByEmailAsync(string mail);
        Task<UserDTO?> GetByIdAsync(int id_user);
        Task<bool> UpdateAsync(UserUpdateDTO userDTO);
    }
}
