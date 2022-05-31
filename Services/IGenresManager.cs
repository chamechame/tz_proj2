using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Models;

namespace WAtest.Services
{
    public interface IGenresManager
    {
        Task<ActionResult<IEnumerable<Genre>>> GetAll();
        Task<ActionResult<Genre>> Get(int id);
        Task Put(int id, Genre genre);
        Task<ActionResult<Genre>> Post(Genre genre);
        Task Delete(int id);

        Task<IEnumerable<Game>> GetGenresToGames(int id);
    }
}
