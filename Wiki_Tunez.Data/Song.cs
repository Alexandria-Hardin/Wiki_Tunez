using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenreType 
    {
        [Display(Name = "Alternative")]
        Alternative,
        [Display(Name = "Blues")]
        Blues,
        [Display(Name = "Classical")]
        Classical,
        [Display(Name = "Country")]
        Country,
        [Display(Name = "Dance")]
        Dance,
        [Display(Name = "Electronic")]
        Electronic,
        [Display(Name = "Hip-Hop")]
        HipHop,
        [Display(Name = "Jazz")]
        Jazz,
        [Display(Name = "Metal")]
        Metal,
        [Display(Name = "Pop")]
        Pop,
        [Display(Name = "Rap")]
        Rap,
        [Display(Name = "Rock & Roll")]
        Rock,
        [Display(Name = "R&B")]
        RnB,
        [Display(Name = "Reggae")]
        Reggae
    }

    public class Song
    {
        public Song()
        {
            ListOfPlaylists = new HashSet<Playlist>();
        }

        [Key]
        public int SongId { get; set; }

        [Required]
        public string Title { get; set; }

        public double RunTime { get; set; }

        [Required]
        [ForeignKey(nameof(Artist))]
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public GenreType TypeOfGenre { get; set; }

        public virtual ICollection<Playlist> ListOfPlaylists { get; set; }

    }
}
