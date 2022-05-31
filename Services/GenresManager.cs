using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Models;
using WAtest.Repositories;

namespace WAtest.Services
{
    public class GenresManager: IGenresManager
    {
        public IGenresRepository _genresRepository;
        public GenresManager(IGenresRepository _genresRepository)
        {
            this._genresRepository = _genresRepository;
        }
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll()
        {
            return await _genresRepository.GetAll();
        }
        public async Task<ActionResult<Genre>> Get(int id)
        {
            return await _genresRepository.Get(id);
        }
        public async Task Put(int id, Genre genre)
        {
            await _genresRepository.Put(id, genre);
        }
        public async Task<ActionResult<Genre>> Post(Genre genre)
        {
            return await _genresRepository.Post(genre);
        }
        public async Task Delete(int id)
        {
            await _genresRepository.Delete(id);
        }

        public async Task<IEnumerable<Game>> GetGenresToGames(int id)
        {
            return await _genresRepository.GetGenresToGames(id);
        }
    }
}
