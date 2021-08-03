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
    public class ArtistController : ApiController
    {

        /// <summary>
        /// Get All Artists
        /// </summary>
        public IHttpActionResult Get()
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtists();
            return Ok(artists);
        }

        /// <summary>
        /// Get Artist By Id
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtistById(id);
            return Ok(artists);
        }

        /// <summary>
        /// Create Artist
        /// </summary>
        public IHttpActionResult Post(ArtistCreate artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.CreateArtist(artist))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Update Artist
        /// </summary>
        public IHttpActionResult Put(ArtistEdit artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.UpdateArtist(artist))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// Delete Artist By Id
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();

            if (!service.DeleteArtist(id))
                return InternalServerError();

            return Ok();
        }

        private ArtistService CreateArtistService()
        {
            var artistService = new ArtistService();
            return artistService;
        }
    }
}
