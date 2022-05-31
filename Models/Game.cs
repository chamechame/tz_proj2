using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WAtest.Models
{
    public class Game
    {
        public Game()
        {
            GameGenres = new HashSet<GameGenre>();
        }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Genre { get; set; }

        public ICollection<GameGenre> GameGenres { get; set; }
    }
}
