using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;

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
                List<SongListItem> listOfSongs = new List<SongListItem>();
                foreach (var song in entity.SongsByArtist)
                {
                    var name = new SongListItem()
                    {
                        SongId = song.SongId,
                        Title = song.Title,
                        RunTime = song.RunTime,
                        Id = song.Id,
                        AlbumId = (int)song.AlbumId,
                        TypeOfGenre = song.TypeOfGenre
                    };
                    listOfSongs.Add(name);
                }
                List<AlbumListItem> listOfAlbums = new List<AlbumListItem>();
                foreach (var album in entity.ListOfAlbums)
                {
                    var name = new AlbumListItem()
                    {
                        AlbumId = album.AlbumId,
                        Title = album.Title
                    };
                    listOfAlbums.Add(name);
                }
                    return
                    new ArtistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        TypeOfArtist = entity.TypeOfArtist,
                        SongsByArtist = listOfSongs,
                        ListOfAlbums = listOfAlbums
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
