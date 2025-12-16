using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.InterfaceService
{
    public interface IAuthorService
    {
        Task<bool> CreateAsync(AuthorCreateDTO dto);
        Task<IEnumerable<AuthorDTO>> GetAllAsync();
        Task<AuthorDTO?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(AuthorUpdateDTO authorDTO);
        Task<IEnumerable<AuthorDTO?>> SearchByNameAsync(string name);
    }
}
