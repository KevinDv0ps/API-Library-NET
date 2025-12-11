using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceRepository;
using Library.Application.Interfaces.InterfaceService;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public async Task<bool> CreateAsync(AuthorCreateDTO authorDTO)
        {
            var author = new Author
            {
                first_name = authorDTO.first_name,
                second_name = authorDTO.second_name,
                first_lastname = authorDTO.first_lastname,
                second_lastname = authorDTO.second_lastname,
                nacionality = authorDTO.nacionality,
                birth_date = authorDTO.birth_date,
                death_date = authorDTO.death_date
            };

            await _authorRepository.AddAsync(author);
            return true;
        }

        public async Task<IEnumerable<AuthorDTO>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAsync();
            return authors.Select(a => new AuthorDTO
            {
                id_author = a.id,
                first_name = a.first_name,
                second_name = a.second_name,
                first_lastname= a.first_lastname,
                second_lastname = a.second_lastname,
                nacionality = a.nacionality,
                birth_date = a.birth_date,
                death_date = a.death_date,
            });
        }

        public async Task<AuthorDTO?> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetAsyncById(id);
            if(author == null) return null;
            return new AuthorDTO
            {
                id_author = author.id,
                first_name = author.first_name,
                second_name = author.second_name,
                first_lastname = author.first_lastname,
                second_lastname = author.second_lastname,
                nacionality = author.nacionality,
                birth_date = author.birth_date,
                death_date = author.death_date,
            };
        }

        public Task<AuthorDTO?> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(AuthorUpdateDTO authorDTO)
        {
            var author = await _authorRepository.GetAsyncById(authorDTO.id);
            if (author == null) return false;

            author.id = authorDTO.id;
            author.first_name = authorDTO.first_name;
            author.second_name = authorDTO.second_name;
            author.first_lastname = authorDTO.first_lastname;
            author.second_lastname = authorDTO.second_lastname;
            author.birth_date = authorDTO.birth_date;
            author.death_date = authorDTO.death_date;

            await _authorRepository.UpdateAsync(author);
            return true;
        }
    }
}
