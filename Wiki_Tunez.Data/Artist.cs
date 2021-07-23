using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    public class Artist
    {
        public enum ArtistType
        {
            Solo,
            Group,
            Band
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ArtistType TypeOfArtist { get; set; }
    }
}
