using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAtest.Models;

namespace WAtest.Repositories
{
    public interface IGamesRepository
    {
        Task<ActionResult<IEnumerable<Game>>> GetAll();
        Task<ActionResult<Game>> Get(int id);
        Task UpdateGame(int id, Game game);
        Task<ActionResult<Game>> Post(Game game);
        Task Delete(int id);
    }
}