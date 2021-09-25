using Microsoft.AspNet.Identity;
using PersonalLibrary.Models.BookRecordModels;
using PersonalLibrary.Services.BookRecordService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalLibrary.WebAPI.Controllers
{
    [Authorize]
    public class BookRecordController : ApiController
    {  
        private BookRecordService CreateBookRecordService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bookRecordService = new BookRecordService(userId);
            return bookRecordService;
        }
       
        [HttpGet]
        public IHttpActionResult Get()
        {
            BookRecordService bookRecordService = CreateBookRecordService();
            var bookRecords = bookRecordService.GetBookRecords();
            return Ok(bookRecords);
        }
        [HttpPost]
        public IHttpActionResult Post(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBookRecordService();

            if (!service.AddBookRecordToList(id))
                return InternalServerError();

            return Ok();
        }
    }
}
