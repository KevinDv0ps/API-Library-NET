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

        public async Task<bool> DeleteAsync(int id_book)
        {
            var book = await _bookRepository.GetByIdAsync(id_book);
            if (book == null) return false;

            await _bookRepository.DeleteAsync(book);
            return true;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(g => new BookDTO
            {
                title = g.title,
                description = g.description,
                published_date = g.published_date,
                is_available = g.is_available,
                Authors = g.Authors.Select(a => new AuthorDTO
                {
                    id_author = a.id,
                    first_name = a.first_name,
                    second_name = a.second_name,
                    first_lastname = a.first_lastname,
                    second_lastname = a.second_lastname,
                    nacionality = a.nacionality,
                    birth_date = a.birth_date,
                    death_date = a.death_date,
                }).ToList(),
                Genres = g.Genres.Select(ge => new GenreDTO
                {
                    id_genre = ge.id,
                    genre_name = ge.genre_name,
                }).ToList(),
                Loan = g.Loan != null ? new LoanDTO
                {
                    id_loan = g.Loan.id,
                    loan_date = g.Loan.loan_date,
                    return_date = g.Loan.return_date,
                    id_user = g.Loan.id_user,
                } : null
            });
        }

        public async Task<IEnumerable<BookDTO>> GetByAuthorAsync(int id_author)
        {
            var books = await _bookRepository.GetByAuthorAsync(id_author);
            
            return books.Select(g => new BookDTO
            {
                title = g.title,
                description = g.description,
                published_date = g.published_date,
                is_available = g.is_available,
                Authors = g.Authors.Select(a => new AuthorDTO
                {
                    id_author = a.id,
                    first_name = a.first_name,
                    second_name = a.second_name,
                    first_lastname = a.first_lastname,
                    second_lastname = a.second_lastname,
                    nacionality = a.nacionality,
                    birth_date = a.birth_date,
                    death_date = a.death_date,
                }).ToList(),
                Genres = g.Genres.Select(ge => new GenreDTO
                {
                    id_genre = ge.id,
                    genre_name = ge.genre_name,
                }).ToList(),
                Loan = g.Loan != null ? new LoanDTO
                {
                    id_loan = g.Loan.id,
                    loan_date = g.Loan.loan_date,
                    return_date = g.Loan.return_date,
                    id_user = g.Loan.id_user,
                } : null
            });
        }

        public async Task<IEnumerable<BookDTO>> GetByGenreAsync(int id_genre)
        {
            var books =await  _bookRepository.GetByGenreAsync(id_genre);
            return books.Select(g => new BookDTO
            {
                title = g.title,
                description = g.description,
                published_date = g.published_date,
                is_available = g.is_available,
                Authors = g.Authors.Select(a => new AuthorDTO
                {
                    id_author = a.id,
                    first_name = a.first_name,
                    second_name = a.second_name,
                    first_lastname = a.first_lastname,
                    second_lastname = a.second_lastname,
                    nacionality = a.nacionality,
                    birth_date = a.birth_date,
                    death_date = a.death_date,
                }).ToList(),
                Genres = g.Genres.Select(ge => new GenreDTO
                {
                    id_genre = ge.id,
                    genre_name = ge.genre_name,
                }).ToList(),
                Loan = g.Loan != null ? new LoanDTO
                {
                    id_loan = g.Loan.id,
                    loan_date = g.Loan.loan_date,
                    return_date = g.Loan.return_date,
                    id_user = g.Loan.id_user,
                } : null
            });
        }

        public async Task<BookDTO?> GetByIdAsync(int id_book)
        {
            var book = await _bookRepository.GetByIdAsync(id_book);
            if (book == null) return null;
            return new BookDTO
            {
                title = book.title,
                description = book.description,
                published_date = book.published_date,
                is_available = book.is_available,
                Authors = book.Authors.Select(a => new AuthorDTO
                {
                    id_author = a.id,
                    first_name = a.first_name,
                    second_name = a.second_name,
                    first_lastname = a.first_lastname,
                    second_lastname = a.second_lastname,
                    nacionality = a.nacionality,
                    birth_date = a.birth_date,
                    death_date = a.death_date,
                }).ToList(),
                Genres = book.Genres.Select(ge => new GenreDTO
                {
                    id_genre = ge.id,
                    genre_name = ge.genre_name,
                }).ToList(),
                Loan = book.Loan != null ? new LoanDTO
                {
                    id_loan = book.Loan.id,
                    loan_date = book.Loan.loan_date,
                    return_date = book.Loan.return_date,
                    id_user = book.Loan.id_user,
                } : null
            };
        }

        public async Task<BookDTO?> SearchByNameAsync(string name)
        {
            var book = await _bookRepository.SearchByNameAsync(name);
            if (book == null) return null;
            return new BookDTO
            {
                title = book.title,
                description = book.description,
                published_date = book.published_date,
                is_available = book.is_available,
                Authors = book.Authors.Select(a => new AuthorDTO
                {
                    id_author = a.id,
                    first_name = a.first_name,
                    second_name = a.second_name,
                    first_lastname = a.first_lastname,
                    second_lastname = a.second_lastname,
                    nacionality = a.nacionality,
                    birth_date = a.birth_date,
                    death_date = a.death_date,
                }).ToList(),
                Genres = book.Genres.Select(ge => new GenreDTO
                {
                    id_genre = ge.id,
                    genre_name = ge.genre_name,
                }).ToList(),
                Loan = book.Loan != null ? new LoanDTO
                {
                    id_loan = book.Loan.id,
                    loan_date = book.Loan.loan_date,
                    return_date = book.Loan.return_date,
                    id_user = book.Loan.id_user,
                } : null
            };
        }

        public async Task<bool> UpdateAsync(BookUpdateDTO bookDTO)
        {
            var book = await _bookRepository.GetByIdAsync(bookDTO.id);
            if (book == null) return false;

            book.title = bookDTO.title;
            book.description = bookDTO.description;
            book.published_date = bookDTO.published_date;
            book.is_available = bookDTO.is_available;
            book.Authors.Clear();
            foreach (var d in bookDTO.authors_ids.Distinct())
            {
                Author? author = await _authorRepository.GetAsyncById(d);
                if (author == null) throw new Exception("Author not found id: " + d);
                book.Authors.Add(author);
            }
            book.Genres.Clear();
            foreach (var id in bookDTO.genres_ids.Distinct())
            {
                Genre? genre = await _genreRepository.GetByidAsync(id);
                if (genre == null) throw new Exception("Genre not found id: " + id);
                book.Genres.Add(genre);
            }

            await _bookRepository.UpdateAsync(book);
            return true;
        }

        public async Task<bool> GetAvailable(BookDTO bookDTO)
        {
            var book = await _bookRepository.GetByIdAsync(bookDTO.id_book);
            if (book == null) throw new Exception("Book does not exist");
            return book.is_available;
        }
    }
}
