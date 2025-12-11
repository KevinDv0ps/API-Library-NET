using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Library.Application.Interfaces.InterfaceRepository
{
    public interface IAuthorRepository
    {
        // Obtener todos los autores registrados.
        Task<IEnumerable<Author>> GetAsync();

        // Obtener un autor por su ID
        // Devuelve null si no existe.
        Task<Author?> GetAsyncById(int id_author);

        // Crear un nuevo autor en la base de datos.
        Task AddAsync(Author author);

        // Actualizar los datos de un autor (nombre, nacionalidad, etc.)
        Task UpdateAsync(Author author);

        // Obtener autores por su nombre
        Task<Author?> SearchByNameAsync(string name);



    }
}
