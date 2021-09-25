using PersonalLibrary.Models.AuthorModels;
using PersonalLibrary.Services.AuthorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers
{
    public class AuthorController : ApiController
    {
        private AuthorService CreateAuthorService()
        {
            var authorService = new AuthorService();
            return authorService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);
        }
        [HttpPost]
        public IHttpActionResult Post(AuthorCreate author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAuthorService();
            if (!service.CreateAuthor(author))
                return InternalServerError();

            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorById(id);
            return Ok(author);
        }
        [HttpPut]
        public IHttpActionResult Put(AuthorEdit author, int id)
        {
            if (id < 1 || id != author.AuthorId || author == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorService();
            service.UpdateAuthor(author, id);

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorService();

            if (!service.DeleteAuthor(id))
                return InternalServerError();

            return Ok();
        }
    }
}

