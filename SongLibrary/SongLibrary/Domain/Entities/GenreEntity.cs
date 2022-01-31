using System.Collections.Generic;

namespace SongLibrary.Domain.Entities
{
    public class GenreEntity
    {
        public int GenreId { get; set; }
        public string Title { get; set; }
        public List<SongEntity> Songs { get; set; } = new List<SongEntity>();
    }
}
