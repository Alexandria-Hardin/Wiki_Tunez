using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Models
{
    public class PlaylistCreate
    {
        public string Name { get; set; }
        public Playlist()
        {
            ListOfSongs = new HashSet<Song>();
        }
    }
}
