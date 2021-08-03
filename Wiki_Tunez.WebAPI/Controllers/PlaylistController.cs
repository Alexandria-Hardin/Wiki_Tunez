using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Wiki_Tunez.Models;
using Wiki_Tunez.Services;

namespace Wiki_Tunez.WebAPI.Controllers
{
    [Authorize]
    public class PlaylistController : ApiController
    {
        /// <summary>
        /// Get All Playlists
        /// </summary>
        public IHttpActionResult Get()
        {
            PlaylistService playlistService = CreatePlaylistService();
            var playlists = playlistService.GetPlaylists();
            return Ok(playlists);
        }

        /// <summary>
        /// Get Playlist By Id
        /// </summary>
        public IHttpActionResult Get(int Id)
        {
            PlaylistService playlistService = CreatePlaylistService();
            var playlist = playlistService.GetPlaylistById(Id);
            return Ok(playlist);
        }

        //public IHttpActionResult Get(Guid UserId)
        //{
        //    PlaylistService playlistService = CreatePlaylistService();
        //    var playlist = playlistService.GetPlaylistByGuid(UserId);
        //    return Ok(playlist);
        //}

        /// <summary>
        /// Create Playlist
        /// </summary>
        public IHttpActionResult Post(PlaylistCreate playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlaylistService();
            if (!service.CreatePlaylist(playlist))
                return InternalServerError();
            return Ok();
        }

        /// <summary>
        /// Update Playlist
        /// </summary>
        public IHttpActionResult Put(PlaylistEdit playlist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePlaylistService();
            if (!service.UpdatePlaylist(playlist))
                return InternalServerError();
            return Ok();
        }

        /// <summary>
        /// Delete Playlist By Id
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePlaylistService();
            if (!service.DeletePlaylist(id))
                return InternalServerError();
            return Ok();
        }
        private PlaylistService CreatePlaylistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var playlistService = new PlaylistService(userId);
            return playlistService;
        }
    }
}

