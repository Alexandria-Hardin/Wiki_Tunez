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

        private AlbumService CreateAlbumService()
        {
            var albumService = new AlbumService();
            return albumService;
        }

        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbums();
            return Ok(albums);
        }

        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateAlbumService();
            var albums = albumService.GetAlbumById(id);
            return Ok(albums);
        }

        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.CreateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAlbumService();

            if (!service.UpdateAlbum(album))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAlbumService();

            if (!service.DeleteAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }
}
