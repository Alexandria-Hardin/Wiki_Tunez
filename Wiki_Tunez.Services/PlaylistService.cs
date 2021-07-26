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
    public class PlaylistService
    {
        private readonly Guid _userId;
        public PlaylistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity =
                new Playlist()
                {
                    UserId = _userId,
                    Name = model.Name,
                    SongId = model.SongId,
                    ListOfSongs = model.ListOfSongs
                    };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Playlists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlaylistListItem> GetPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Playlists
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new PlaylistListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            ListOfSongs = e.ListOfSongs
                        }
                        );
                return query.ToArray();
            }
        }

        public PlaylistDetail GetPlaylistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.Id == id && e.UserId == _userId);
                return
                    new PlaylistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        SongId = entity.SongId,
                        UserId = entity.UserId,
                        ListOfSongs = entity.ListOfSongs
                    };
            }
        }

        public PlaylistDetail GetPlaylistById(Guid UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.UserId == _userId);
                return
                    new PlaylistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        SongId = entity.SongId,
                        UserId = entity.UserId,
                        ListOfSongs = entity.ListOfSongs
                    };
            }
        }

        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.Id == model.Id && e.UserId == _userId);
                entity.Name = model.Name;
                entity.SongId = model.SongId;
                entity.ListOfSongs = model.ListOfSongs;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlaylist(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.Id == Id && e.UserId == _userId);
                ctx.Playlists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //add way to delete and add songs already inside the playlist
    }
}
