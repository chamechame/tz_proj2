using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAtest.Data;
using WAtest.Models;
using WAtest.Services;

namespace WAtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesManager gamesManager;
        public GamesController(IGamesManager gamesManager)
        {
            this.gamesManager = gamesManager;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            return await gamesManager.GetAll();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            if (await gamesManager.Get(id) == null)
            {
                return NotFound();
            }
            return await gamesManager.Get(id);
        }
        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task PutGame(int id, Game game)
        {
             await gamesManager.UpdateGame(id, game);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
          //  return await gamesManager.Post(game);
            return CreatedAtAction("GetGame", new { id = game.GameId }, await gamesManager.Post(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task DeleteGame(int id)
        {
           await gamesManager.Delete(id);
        }

    }
}
