using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Models
{
    public class ArtistCreate
    {
        public enum ArtistType
        {
            Solo,
            Group,
            Band
        }
        public string Name { get; set; }
        public ArtistType TypeOfArtist { get; set; }
    }
}
