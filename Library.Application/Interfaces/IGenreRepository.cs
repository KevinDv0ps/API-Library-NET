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
        public Task<ActionResult<IEnumerable<Genre>>> GetGenresAsync();
        public Task<ActionResult<Genre>> PostGenresAsync();

    }
}
