using MassCultureLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassCultureLibrary.Animes
{
    public class AnimeService : IAnimeService
    {
        IAnimeRepository _repository;

        public AnimeService(IAnimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anime> AddAnimeAsync(Anime anime) // реализация добавления объекта
        {
            return await _repository.AddAsync(anime);
        }

        public async Task DeleteAnimeByIdAsync(Guid animeId) // реализация удаления по Id
        {
            var anime = _repository.GetByIdAsync(animeId);
            if (anime == null)
                throw new KeyNotFoundException($"Аниме с Id: {animeId} не найдена. ");

            await _repository.DeleteAsync(animeId);
        }

        public Task DeleteAnimeAsync(Anime anime) // удаление всего объекта
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Anime>> GetAnimeAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Anime?> GetAnimeByIdAsync(Guid animeId) // реализация получения по Id
        {
            return await _repository.GetByIdAsync(animeId);
        }

        public Task<Anime?> GetAnimeByTitleAsync(string title) // получение аниме по названию
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anime>> GetAnimeByGenreAsync(string genre) // получение списка аниме по выбранному жанру
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anime>> GetAnimeByStatusAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<Anime> UpdateAnimeAsync(Guid animeId, AnimeUpdateDto updateInfo)
        {
            throw new NotImplementedException();
        }
    }
}
