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
                            AlbumId = e.AlbumId,
                            Title = e.Title,
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
                    .Single(e => e.AlbumId == id);
                    List<SongListItem> listOfSongs = new List<SongListItem>();
                    foreach (var song in entity.AlbumOfSongs)
                    {
                        var name = new SongListItem()
                        {
                            SongId = song.SongId,
                            Title = song.Title,
                            Id = song.Id,
                            AlbumName = song.Album.Title
                        };
                        listOfSongs.Add(name);
                    }
                return
                    new AlbumDetail
                    {
                        AlbumId = entity.AlbumId,
                        Title = entity.Title,
                        AmountOfSongs = entity.AmountOfSongs,
                        ArtistId = entity.ArtistId,
                        TypeOfGenre = entity.TypeOfGenre,
                        AlbumOfSongs = listOfSongs
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
                    .Single(e => e.AlbumId == model.AlbumId);

                entity.AlbumId = model.AlbumId;
                entity.Title = model.Title;
                entity.AmountOfSongs = model.AmountOfSongs;
                entity.ArtistId = model.ArtistId;
                entity.TypeOfGenre = model.TypeOfGenre;

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
                    .Single(e => e.AlbumId == id);
                ctx.Albums.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
