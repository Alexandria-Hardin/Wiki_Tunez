using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    public class PlaylistDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<Song> ListOfSongs { get; set; }
    }
}
