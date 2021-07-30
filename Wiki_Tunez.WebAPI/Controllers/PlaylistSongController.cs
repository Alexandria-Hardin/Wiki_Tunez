using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Wiki_Tunez.Models;
using Wiki_Tunez.Services;

namespace Wiki_Tunez.WebAPI.Controllers
{
    public class PlaylistSongController : ApiController
    {
        public IHttpActionResult Post(PlaylistSongCreate playlistSong)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlaylistSongService();
            if (!service.CreatePlaylistSong(playlistSong))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int playlistId, int songId) 
        {
            var service = CreatePlaylistSongService();

            if (!service.DeleteSongFromPlaylist(playlistId, songId))
                return InternalServerError();

            return Ok();
        }

        private PlaylistSongService CreatePlaylistSongService()
        {
            var playlistSongService = new PlaylistSongService();
            return playlistSongService;
        }
    }
}
