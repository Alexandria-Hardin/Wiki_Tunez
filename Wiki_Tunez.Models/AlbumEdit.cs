using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    class AlbumEdit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AmountOfSongs { get; set; }
        public int ArtistId { get; set; }
        public GenreType TypeOfGenre { get; set; }
        public virtual ICollection<Song> AlbumOfSongs { get; set; }
    }
}
