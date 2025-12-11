using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.InterfaceService
{
    public interface IGenreService
    {
        Task<bool> CreateAsync(GenreCreateDTO dto);
        Task<IEnumerable<GenreDTO>> GetAllAsync();
        Task<GenreDTO?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(GenreUpdateDTO dto);
    }
}
