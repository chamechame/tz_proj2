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
    public class GenresController : ControllerBase
    {
        private readonly IGenresManager genresManager;
        public GenresController(IGenresManager genresManager)
        {
            this.genresManager = genresManager;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await genresManager.GetAll();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            if (await genresManager.Get(id) == null)
            {
                return NotFound();
            }

            return await genresManager.Get(id);
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task PutGenre(int id, Genre genre)
        {
            await genresManager.Put(id, genre);
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            return CreatedAtAction("GetGenre", new { id = genre.GenreId }, await genresManager.Post(genre));
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task DeleteGenre(int id)
        {
            await genresManager.Delete(id);
        }

        // GET: api/GenresGames/5
        [HttpGet("GenresGames{id}")]
        public async Task<IEnumerable<Game>> GetsGenresToGames(int id)
        {
            return await genresManager.GetGenresToGames(id);
        }



    }
}
