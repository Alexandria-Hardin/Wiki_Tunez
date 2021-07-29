using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    public class PlaylistCreate
    {
        public string Name { get; set; }
        //public int SongId { get; set; }
        public virtual ICollection<Song> ListOfSongs { get; set; }
    }
}
