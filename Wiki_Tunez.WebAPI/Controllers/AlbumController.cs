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
    public class AlbumController : ApiController
    {

        /// <summary>
        /// Get All Albums
        /// </summary>
        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbums();
            return Ok(albums);
        }

        /// <summary>
        /// Get Album By Id
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbumById(id);
            return Ok(albums);
        }

        /// <summary>
        /// Create Album
        /// </summary>
        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Update Album
        /// </summary>
        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Delete Album by Id
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
        private AlbumService CreateAlbumService()
        {
            var albumService = new AlbumService();
            return albumService;
        }
    }
}
