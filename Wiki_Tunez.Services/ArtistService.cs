﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;
using Wiki_Tunez.WebAPI.Data;

namespace Wiki_Tunez.Services
{
    public class ArtistService
    {
        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    Name = model.Name,
                    TypeOfArtist = (Artist.ArtistType)model.TypeOfArtist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Artists
                    .Where(e => e.Id == Id)
                    .Select(
                        e =>
                        new ArtistListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                        }
                        );
                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == Id);
                return
                    new ArtistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        TypeOfArtist = (ArtistDetail.ArtistType)entity.TypeOfArtist
                    };
            }

        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.TypeOfArtist = (Artist.ArtistType)model.TypeOfArtist;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == Id);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}