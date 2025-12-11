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
    public interface IBookService
    {
        Task<BookDTO?> GetByIdAsync(int id_book);
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<bool> AddAsync(BookCreateDTO bookDTO);
        Task<bool> UpdateAsync(BookUpdateDTO bookDTO);
        Task<bool> DeleteAsync(int id_book);
        Task<IEnumerable<BookDTO>> GetByAuthorAsync(int id_author);
        Task<IEnumerable<BookDTO>> GetByGenreAsync(int id_genre);
        Task<BookDTO?> SearchByNameAsync(string name);
    }
}
