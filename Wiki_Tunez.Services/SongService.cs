using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;

namespace Wiki_Tunez.Services
{
    public class SongService
    {
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {                   
                    Title = model.Title,
                    RunTime = model.RunTime,
                    Id = model.Id,
                    AlbumId = model.AlbumId,
                    TypeOfGenre = model.TypeOfGenre

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        

        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Select(
                             e =>
                                new SongListItem
                                {
                                    SongId = e.SongId,
                                    Title = e.Title,
                                    Id = e.Id,
                                    AlbumName = e.Album.Title
                                }
                         );
                return query.ToArray();
            }
        }

        public SongDetail GetSongByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == id);
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                        RunTime = entity.RunTime,
                        Id = entity.Id,
                        AlbumName = entity.Album.Title,
                        TypeOfGenre = entity.TypeOfGenre
                    };
            }
        }

        public SongDetail GetSongByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.Title == title);
                    return
                        new SongDetail
                        {
                            SongId = entity.SongId,
                            Title = entity.Title,
                            RunTime = entity.RunTime,
                            Id = entity.Id,
                            AlbumName = entity.Album.Title,
                            TypeOfGenre = entity.TypeOfGenre
                        };     
            }
        }

        public bool UpdateSong(SongEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == model.SongId);
                entity.Title = model.Title;
                entity.RunTime = model.RunTime;
                entity.TypeOfGenre = model.TypeOfGenre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSong(int songId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.SongId == songId);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
