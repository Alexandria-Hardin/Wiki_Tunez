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
    [Authorize]
    public class SongController : ApiController
    {
        /// <summary>
        /// Get All Songs
        /// </summary>
        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var songs = songService.GetSongs();
            return Ok(songs);
        }

        /// <summary>
        /// Get Song By Id
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongByID(id);
            return Ok(song);
        }

        /// <summary>
        /// Get Song By Title
        /// </summary>
        public IHttpActionResult Get(string title)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongByTitle(title);
            return Ok(song);
        }

        /// <summary>
        /// Create Song
        /// </summary>
        public IHttpActionResult Post(SongCreate song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.CreateSong(song))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Update Song
        /// </summary>
        public IHttpActionResult Put(SongEdit song)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Delete Song By Id
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id))
                return InternalServerError();

            return Ok();
        }

        private SongService CreateSongService()
        {
            var songService = new SongService();
            return songService;
        }
    }
}
