using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Data;
using WAtest.Models;

namespace WAtest.Repositories
{
    public class GenresRepository: IGenresRepository
    {
        private readonly WAtestContext _context;
        public GenresRepository(WAtestContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }
        public async Task<ActionResult<Genre>> Get(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            return genre;
        }
        public  Task<IEnumerable<Game>> GetGenresToGames(int id)
        {
            var genre =  _context.GameGenres.Where(y => y.GenreId == id)
                .Select(x => x.Game);
            return  Task.FromResult(genre.AsEnumerable());
        }
        public async Task Put(int id, Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<ActionResult<Genre>> Post(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return  genre;
        }
        public async Task Delete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.GenreId == id);
        }
    }
}
