using System;
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
                    TypeOfArtist = model.TypeOfArtist
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Artists
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

        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == id);
                return
                    new ArtistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        TypeOfArtist = entity.TypeOfArtist
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
                entity.TypeOfArtist = model.TypeOfArtist;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Artists
                    .Single(e => e.Id == id);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
