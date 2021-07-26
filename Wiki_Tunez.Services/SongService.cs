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
    public class SongService
    {
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {                   
                    Title = model.Title,
                    RunTime = model.RunTime,
                    Id = model.ArtistId,
                    TypeOfGenre = model.TypeOfGenre,

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
                        //.Where(e => e.Id == eArtistId)
                        .Select(
                             e =>
                                new SongListItem
                                {
                                    SongId = e.SongId,
                                    Title = e.Title,
                                    RunTime = e.RunTime,
                                    ArtistId = e.Id,
                                    TypeOfGenre = e.TypeOfGenre
                                }
                         );
                return query.ToArray();
            }
        }

        public SongDetail GetSongByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Songs
                        .Single(e => e.Title == name);
                return
                    new SongDetail
                    {
                        SongId = entity.SongId,
                        Title = entity.Title,
                        RunTime = entity.RunTime,
                        ArtistId = entity.Id,
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

        public bool DeleteNote(int songId)
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
