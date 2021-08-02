using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    public class ArtistDetail
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistType TypeOfArtist { get; set; }
        public virtual ICollection<AlbumListItem> ListOfAlbums { get; set; } 
        public virtual ICollection<SongListItem> SongsByArtist { get; set; } 

    }
}
