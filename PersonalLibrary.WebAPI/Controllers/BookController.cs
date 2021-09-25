using Microsoft.AspNet.Identity;
using PersonalLibrary.Models.BookModels;
using PersonalLibrary.Services.BookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers
{
    public class BookController : ApiController
    {
        private BookService CreateBookService()
        {
            //Add Guid later w/ users like ElevenNote
            //var userId = int.Parse(User.Identity.GetUserId());
            var bookService = new BookService();
            return bookService;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            BookService bookService = CreateBookService();
            var books = bookService.GetBooks();
            return Ok(books);
        }
        public IHttpActionResult Get(int id)
        {
            BookService bookService = CreateBookService();
            var book = bookService.GetBookById(id);
            return Ok(book);
        }
        public IHttpActionResult Post(BookCreate book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookService();

            if (!service.CreateBook(book))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(BookEdit book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BookService service = CreateBookService();
            if (!service.UpdateBook(book))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            BookService service = CreateBookService();

            if (!service.DeleteBook(id))
                return InternalServerError();

            return Ok();
        }
    }
}

