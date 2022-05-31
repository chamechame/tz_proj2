using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Models;
using WAtest.Repositories;

namespace WAtest.Services
{
    public class GamesManager: IGamesManager
    {
        public IGamesRepository _gamesRepository;
        public GamesManager(IGamesRepository _gamesRepository)
        {
            this._gamesRepository = _gamesRepository;
        }
        public async Task<ActionResult<IEnumerable<Game>>> GetAll()
        {
            return await _gamesRepository.GetAll();
        }
        public async Task<ActionResult<Game>> Get(int id)
        {
            return await _gamesRepository.Get(id);
        }
        public async Task UpdateGame(int id, Game game)
        {
             await _gamesRepository.UpdateGame(id, game);
        }
        public async Task<ActionResult<Game>> Post(Game game)
        {
            return await _gamesRepository.Post(game);
        }
        public async Task Delete(int id)
        {
            await _gamesRepository.Delete(id);
        }

    }
}