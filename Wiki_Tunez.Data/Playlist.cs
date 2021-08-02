using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public virtual ICollection<PlaylistSong> ListOfSongs { get; set; }

        public Playlist()
        {
            ListOfSongs = new HashSet<PlaylistSong>();
        }
    }
}
