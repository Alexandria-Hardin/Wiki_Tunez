﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki_Tunez.Models
{
    class ArtistDetail
    {
        public enum ArtistType
        {
            Solo,
            Group,
            Band
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistType TypeOfArtist { get; set; }
    }
}
