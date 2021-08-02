using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ArtistType
    {
        [Display(Name ="Solo")]
        Solo,
        [Display(Name ="Group")]
        Group,
        [Display(Name ="Band")]
        Band
    }

    public class Artist
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ArtistType TypeOfArtist { get; set; }

        public virtual ICollection<Album> ListOfAlbums { get; set; } = new List<Album>();
        public virtual ICollection<Song> SongsByArtist { get; set; } = new List<Song>();
    }
}
