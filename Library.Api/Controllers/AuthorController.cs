using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthors()
        {
            try
            {
                var authors = await _authorService.GetAllAsync();
                if (authors == null || !authors.Any())
                {
                    return NotFound("No authors found.");
                }
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null)
                {
                    return NotFound($"Author with ID {id} not found.");
                }
                return Ok(author);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("search/{name}")]
        public async Task<ActionResult> SearchAuthorsByName([FromQuery] string name)
        {
            try
            {
                var authors = await _authorService.SearchByNameAsync(name);
                if (authors == null || !authors.Any())
                {
                    return NotFound($"No authors found with name containing '{name}'.");
                }
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorCreateDTO dto)
        {
            try
            {
                var result = await _authorService.CreateAsync(dto);
                if (!result)
                {
                    return BadRequest("Failed to create author.");
                }
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAuthor([FromBody] AuthorUpdateDTO dto)
        {
            try
            {
                var result = await _authorService.UpdateAsync(dto);
                if (!result)
                {
                    return BadRequest("Failed to update author.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
