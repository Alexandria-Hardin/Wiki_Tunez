using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    public class Album
    {
        [Key] 
        public int AlbumId { get; set; } 
        [Required]
        public string Title { get; set; }
        [Required]
        public int AmountOfSongs { get; set; } 

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public GenreType TypeOfGenre { get; set; }
        public virtual ICollection<Song> AlbumOfSongs { get; set; } 

        public Album()
        {
            AlbumOfSongs = new HashSet<Song>();
        }
    }
}
