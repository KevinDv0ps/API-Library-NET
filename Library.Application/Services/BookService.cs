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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }
        public async Task<bool> AddAsync(BookCreateDTO bookDTO)
        {
            var exist = await _bookRepository.SearchByNameAsync(bookDTO.title);
            if (exist != null) return false;

            List<Author> authors = new List<Author>();
            foreach(var d in bookDTO.authors_ids)
            {
                Author? author = await _authorRepository.GetAsyncById(d);
                if (author == null) throw new Exception("Author not found id: " + d);
                authors.Add(author);
            }

            List<Genre> genres = new List<Genre>();
            foreach(var id  in bookDTO.genres_ids)
            {
                Genre? genre = await _genreRepository.GetByidAsync(id);
                if (genre == null) throw new Exception("Genre not found id: "+ id);
                genres.Add(genre);
            }

            Book book = new Book
            {
                title = bookDTO.title,
                description = bookDTO.description,
                published_date = bookDTO.published_date,
                is_available = bookDTO.is_available,
                Authors = authors,
                Genres = genres
            };

            await _bookRepository.AddAsync(book);
            return true;
        }

        public Task<bool> DeleteAsync(int id_book)
        {
            
        }

        public Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetByAuthorAsync(int id_author)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetByGenreAsync(int id_genre)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO?> GetByIdAsync(int id_book)
        {
            throw new NotImplementedException();
        }

        public Task<BookDTO?> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BookUpdateDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
