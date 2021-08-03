using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;

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
                    Name = model.Name
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
                            UserId = e.UserId
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
                List<SongListItem> listOfSongs = new List<SongListItem>();
                foreach (var song in entity.ListOfSongs)
                {
                    var name = new SongListItem()
                    {
                        SongId = song.SongId,
                        Title = song.Song.Title,
                        Id = song.Song.Id,
                        AlbumId = (int)song.Song.AlbumId
                    };
                    listOfSongs.Add(name);
                }
                return
                    new PlaylistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        UserId = entity.UserId,
                        ListOfSongs = listOfSongs
                    };
            }
        }

        public PlaylistDetail GetPlaylistByGuid(Guid UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Playlists
                    .Single(e => e.UserId == _userId);
                List<SongListItem> listOfSongs = new List<SongListItem>();
                foreach (var song in entity.ListOfSongs)
                {
                    var name = new SongListItem()
                    {
                        SongId = song.SongId,
                        Title = song.Song.Title,
                        Id = song.Song.Id,
                        AlbumId = (int)song.Song.AlbumId
                    };
                    listOfSongs.Add(name);
                }

                    return
                    new PlaylistDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        UserId = entity.UserId,
                        ListOfSongs = listOfSongs
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

            //public void AddSongToPlaylist(int SongId, int PlaylistId)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var foundSong = ctx.Songs.Single(s => s.SongId == SongId);
            //        var foundPlaylist = ctx.Playlists.Single(p => p.Id == PlaylistId);
            //        foundPlaylist.ListOfSongs.Add(foundSong);
            //        var testing = ctx.SaveChanges();
            //    }
            //}

            //public void DeleteSongFromPlaylist(int SongId, int PlaylistId)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var foundSong = ctx.Songs.Single(s => s.SongId == SongId);
            //        var foundPlaylist = ctx.Playlists.Single(p => p.Id == PlaylistId);
            //        foundPlaylist.ListOfSongs.Remove(foundSong);
            //        var testing = ctx.SaveChanges();
            //    }
            //}
        }
    }

