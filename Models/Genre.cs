using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WAtest.Models

{
    public class Genre
    {
        public Genre()
        {
            GameGenres = new HashSet<GameGenre>();
        }
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<GameGenre> GameGenres { get; set; }

    }
}
