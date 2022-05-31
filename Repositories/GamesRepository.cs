using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Data;
using WAtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace WAtest.Repositories
{
    public class GamesRepository: IGamesRepository
    {
        private readonly WAtestContext _context;
        public GamesRepository(WAtestContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Game>>> GetAll()
        { 
            return await _context.Games
                .AsNoTracking()
                .Include(i => i.GameGenres).ThenInclude(i => i.Genre)
                .ToListAsync();
        }
        public async Task<ActionResult<Game>> Get(int id)
        {
            var game = await _context.Games
                .AsNoTracking()
                .Include(i => i.GameGenres).ThenInclude(i => i.Genre)
                .SingleOrDefaultAsync(w => w.GameId == id);
            return game;
        }
        public async Task UpdateGame(int id, Game game)
        {
                _context.Entry(game).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var gameGenres = await _context.GameGenres.Where(w => w.GameId == game.GameId).ToListAsync();
                if (gameGenres.Count() > 0)
                {
                    _context.GameGenres.RemoveRange(gameGenres);
                    await _context.SaveChangesAsync();
                }
                if (game.GameGenres.Count() > 0)
                {
                    _context.GameGenres.AddRange(game.GameGenres);
                    await _context.SaveChangesAsync();
                }
        }
        public async Task<ActionResult<Game>> Post(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            if (game.GameGenres.Count() > 0)
            {
                _context.GameGenres.AddRange(game.GameGenres);
                await _context.SaveChangesAsync();
            }
            return  game;
        }
        public async Task Delete(int id)
        {
            var game = await _context.Games.FindAsync(id);

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }

    }
}