using System;
using System.Collections.Generic;

namespace SongLibrary.Domain.Entities
{
    public class ArtistEntity
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string InstagramURL { get; set; }

        public ICollection<SongEntity> Songs { get; set; }
    }
}
