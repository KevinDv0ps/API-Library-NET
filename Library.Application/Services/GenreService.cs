using Library.Entities;
using Library.Application.Interfaces.InterfaceRepository;
using Library.Application.Interfaces.InterfaceService;
using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.ResponseDTOs;
using Library.Application.DTOs.UpdateDTOs;

namespace Library.Application.Services
{
    public class GenreService: IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<bool> CreateAsync(GenreCreateDTO genreDto)
        {
            var exist = _genreRepository.GetByNameAsync(genreDto.genre_name);
            if (exist != null) return false;
            var genre = new Genre
            {
                genre_name = genreDto.genre_name,
            };
            await _genreRepository.AddAsync(genre);
            return true;
        }

        public async Task<IEnumerable<GenreDTO>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();

            return genres.Select(g => new GenreDTO
            {
                id_genre = g.id,
                genre_name = g.genre_name
            });
        }

        public async Task<GenreDTO?> GetByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByidAsync(id);
            if (genre == null) return null;
            return new GenreDTO
            {
                id_genre = genre.id,
                genre_name = genre.genre_name
            };
        }

        public async Task<bool> UpdateAsync(GenreUpdateDTO genreDto)
        {
            var genre = await _genreRepository.GetByidAsync(genreDto.id);
            if(genre == null) return false;

            var exist =  await _genreRepository.GetByNameAsync(genreDto.genre_name);
            if (exist != null && exist.id != genreDto.id) return false;

            genre.genre_name = genreDto.genre_name;
            await _genreRepository.UpdateAsync(genre);
            return true;
        }
    }
}
