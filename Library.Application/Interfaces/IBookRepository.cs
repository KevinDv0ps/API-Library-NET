using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookRepository
    {
        public Task<ActionResult<IEnumerable<Book>>> GetBooksAsync();
        public Task<ActionResult<Book>> GetBookAsyncById(int id_book);
        public Task<ActionResult<Book>> GetBookAsyncByGenreIdOrName(int? id_genre, string? name_genre);
        public Task<ActionResult<Book>> GetBookAsyncByAuthorIdOrName(int? id_author, string? name_author);
        public Task<ActionResult<Book>> PostBooksAsync();
        public Task<ActionResult<Book>> UpadteBooksAsync(int id_book);
        //public Task<ActionResult<Book>> ChangeBookState(int id_book);
    }
}
