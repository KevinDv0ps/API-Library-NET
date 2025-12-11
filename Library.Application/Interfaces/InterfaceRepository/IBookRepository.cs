using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces.InterfaceRepository
{
    public interface IBookRepository
    {
        // Obtener un libro por su ID
        // Devuelve null si no existe.
        Task<Book?> GetByIdAsync(int id_book);

        // Obtener todos los libros registrados.
        Task<IEnumerable<Book>> GetAllAsync();

        // Crear un nuevo libro en la base de datos.
        Task AddAsync(Book book);

        // Actualizar los datos de un libro (título, género, autor, etc.)
        Task UpdateAsync(Book book);

        // Eliminar un libro (si quieres manejar borrado lógico, lo harías en Infrastructure)
        Task DeleteAsync(int id_book);

        // Obtener todos los libros de un autor específico
        Task<IEnumerable<Book>> GetByAuthorAsync(int id_author);

        // Obtener todos los libros de un género específico
        Task<IEnumerable<Book>> GetByGenreAsync(int id_genre);

        // Obtener libros por su título
        Task<Book?> SearchByNameAsync(string name);
    }
}
