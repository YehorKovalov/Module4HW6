using System;
using System.Collections.Generic;

namespace SongLibrary.Domain.Entities
{
    public class SongEntity
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public DateTimeOffset ReleasedDate { get; set; }

        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }

        public ICollection<ArtistEntity> Artists { get; set; }
    }
}
