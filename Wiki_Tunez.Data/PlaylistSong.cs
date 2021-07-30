using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    public class PlaylistSong
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Playlist))]
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
