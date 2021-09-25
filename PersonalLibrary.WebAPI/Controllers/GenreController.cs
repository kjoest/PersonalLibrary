using PersonalLibrary.Models.GenreModels;
using PersonalLibrary.Services.GenreServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers
{
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var service = new GenreService();
            return service;
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] GenreCreate genre)
        {
            if (genre == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();
            var success = service.CreateGenre(genre);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var service = CreateGenreService();
            var genres = service.GetAllGenres();
            if (genres == null)
                return BadRequest();
            return Ok(genres);
        }
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateGenreService();
            var genre = service.GetAllGenresById(id);
            return Ok(genre);
        }
        [HttpGet]
        public IHttpActionResult GetByType([FromUri] string genreType)
        {
            if (genreType == null)
                return BadRequest();

            var service = CreateGenreService();
            var genre = service.GetAllGenresByGenreType(genreType);
            return Ok(genre);
        }
        [HttpPut]
        public IHttpActionResult Put([FromBody] GenreEdit genre, [FromUri] int id)
        {
            if (id < 1 || id != genre.Id || genre == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGenreService();
            service.UpdateGenre(genre, id);

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteById([FromUri] int id)
        {
            if (id < 1)
                return BadRequest();

            var service = CreateGenreService();
            var success = service.DeleteGenreById(id);
            if (success)
                return Ok();

            return InternalServerError();
        }
    }
}