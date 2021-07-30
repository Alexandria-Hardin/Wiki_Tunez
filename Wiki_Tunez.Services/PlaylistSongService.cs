using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki_Tunez.Data;
using Wiki_Tunez.Models;

namespace Wiki_Tunez.Services
{
    public class PlaylistSongService
    {
        public bool CreatePlaylistSong(PlaylistSongCreate model)
        {
            var entity =
                new PlaylistSong()
                {
                    PlaylistId = model.PlaylistId,
                    SongId = model.SongId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlaylistSongs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public void DeleteSongFromPlaylist(int SongId, int PlaylistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundSong = ctx.PlaylistSongs.Single(s => s.SongId == SongId && s.PlaylistId == PlaylistId);
                ctx.PlaylistSongs.Remove(foundSong);
                var testing = ctx.SaveChanges();
            }
        }
    }
}
