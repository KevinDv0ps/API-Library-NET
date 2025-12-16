using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGenres()
        {
            try
            {
                var genres = await _genreService.GetAllAsync();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGenreById(int id)
        {
            try
            {
                var genre = await _genreService.GetByIdAsync(id);
                if (genre == null)
                {
                    return NotFound();
                }
                return Ok(genre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateGenre([FromBody] GenreCreateDTO Genredto)
        {
            try
            {
                var result = await _genreService.CreateAsync(Genredto);
                if (result)
                {
                    return Created();
                }
                return BadRequest("Could not create genre.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateGenre([FromBody] GenreUpdateDTO Genredto)
        {
            try
            {
                var result = await _genreService.UpdateAsync(Genredto);
                if (result)
                {
                    return NoContent();
                }
                return BadRequest("Could not update genre.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
