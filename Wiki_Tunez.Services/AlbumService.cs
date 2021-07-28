using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;

namespace Wiki_Tunez.Services
{
    public class AlbumService
    {
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity =
                new Album()
                {
                    Title = model.Title,
                    AmountOfSongs = model.AmountOfSongs,
                    ArtistId = model.ArtistId,
                    TypeOfGenre = model.TypeOfGenre,
                    AlbumOfSongs = model.AlbumOfSongs
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Albums
                    .Select(
                        e =>
                        new AlbumListItem
                        {
                            Id = e.Id,
                            Title = e.Title,
                            AlbumOfSongs = e.AlbumOfSongs
                        }
                        );
                return query.ToArray();
            }
        }

        public AlbumDetail GetAlbumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.Id == id);
                return
                    new AlbumDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        AmountOfSongs = entity.AmountOfSongs,
                        ArtistId = entity.ArtistId,
                        TypeOfGenre = entity.TypeOfGenre,
                        AlbumOfSongs = entity.AlbumOfSongs
                    };
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.AmountOfSongs = model.AmountOfSongs;
                entity.ArtistId = model.ArtistId;
                entity.TypeOfGenre = model.TypeOfGenre;
                entity.AlbumOfSongs = model.AlbumOfSongs;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAlbum(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Albums
                    .Single(e => e.Id == id);
                ctx.Albums.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
