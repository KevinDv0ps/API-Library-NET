using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IAuthorRepository
    {


        public Task<ActionResult<IEnumerable<Author>>> GetAuthorsAsync();
        public Task<ActionResult<IEnumerable<Author>>> PostAuthorAsync(Author author);

    }
}
