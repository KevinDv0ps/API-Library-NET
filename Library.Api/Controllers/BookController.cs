using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookService.GetAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("searchByAuthor/{id_author}")]
        public async Task<ActionResult> GetBooksByAuthor(int id_author)
        {
            try
            {
                var books = await _bookService.GetByAuthorAsync(id_author);
                if (books == null || !books.Any())
                {
                    return NotFound();
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }
        [HttpGet("searchByGenre/{id_genre}")]
        public async Task<ActionResult> GetBooksByGenre(int id_genre)
        {
            try
            {
                var books = await _bookService.GetByGenreAsync(id_genre);
                if (books == null || !books.Any())
                {
                    return NotFound();
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("searchByName/{name}")]
        public async Task<ActionResult> GetBookByName(string name)
        {
            try
            {
                var book = await _bookService.SearchByNameAsync(name);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("isAvailable/{id}")]
        public async Task<ActionResult> IsBookAvailable(int id)
        {
            try
            {
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                var isAvailable = await _bookService.GetAvailable(book);
                return Ok(isAvailable);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] BookCreateDTO bookCreateDTO)
        {
            try
            {
                var result = await _bookService.AddAsync(bookCreateDTO);
                if (!result)
                {
                    return BadRequest("Failed to add the book.");
                }
                return Ok("Book added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpPut]
        public async Task<ActionResult> UpdateBook([FromBody] BookUpdateDTO bookUpdateDTO)
        {
            try
            {
                var result = await _bookService.UpdateAsync(bookUpdateDTO);
                if (!result)
                {
                    return BadRequest("Failed to update the book.");
                }
                return Ok("Book updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
