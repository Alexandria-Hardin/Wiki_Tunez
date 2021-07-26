using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Data
{
    public enum GenreType 
    {
        Pop = 1, Country, Rap, Rock, Classical, RnB, Indie, Jazz, Metal, Alternative, Punk, HipHop, Blues, Folk, Electronic, Reggae
    }
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        [Required]
        public string Title { get; set; }

        public double RunTime { get; set; }

        [ForeignKey(nameof(Artist))]
        public int Id { get; set; }
        public virtual Artist Artist { get; set; }

        //public virtual ICollection<Artist> ListOfArtists { get; set; }

        //public Song()
        //{
        //    ListOfArtists = new HashSet<Artist>();
        //}

        public GenreType TypeOfGenre { get; set; }

    }
}
