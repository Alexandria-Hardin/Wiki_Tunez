using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;

namespace Wiki_Tunez.Models
{
    public class ArtistCreate
    {
        public string Name { get; set; }
        public ArtistType TypeOfArtist { get; set; }
    }
}
