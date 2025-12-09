using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IGenreRepository
    {
        // Obtener todos los géneros registrados.
        Task<IEnumerable<Genre>> GetAllAsync();
        // Obtener un género por su ID
        // Devuelve null si no existe.
        Task<Genre?> GetByidAsync(int id_genre);
        // Crear un nuevo género en la base de datos.
        Task AddAsync(Genre genre);
        // Actualizar los datos de un género (nombre)
        Task UpdateAsync(Genre genre);
        // Obtener géneros por su nombre (devuelve un solo resultado o null)
        Task<Genre?> GetByNameAsync(string name);

    }
}
