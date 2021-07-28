using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    public class AlbumListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Song> AlbumOfSongs { get; set; }
    }
}
