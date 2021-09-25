using PersonalLibrary.Data;
using PersonalLibrary.Models.BookRecordModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.BookRecordService
{
    public class BookRecordService
    {
         private readonly Guid _userId;
        public BookRecordService(Guid userId)
         {
             _userId = userId;
         }

        public bool AddBookRecordToList(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Books.SingleOrDefault(b => b.Id == bookId);
                var bookRecord = new BookRecord() 
                {
                OwnerId = _userId.ToString(),
                Id = entity.Id,
                Title = entity.Title,
                Summary = entity.Summary,
                BestSeller = entity.BestSeller,
                DatePublished = entity.DatePublished,
                Author = entity.Author,
                Genre = entity.Genre
            };
                ctx.MyList.Add(bookRecord);

                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<BookRecordListDetail> GetBookRecords()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var querey =
                    ctx.MyList.Where(b => b.OwnerId == _userId.ToString())
                    .Select(b =>
                        new BookRecordListDetail
                        {
                            Id = b.Id,
                            Title = b.Title,
                            DatePublished = b.DatePublished,
                            Author = b.Author,
                            Genre = b.Genre
                        }
                    );
                return querey.ToArray();
            }
        }
    }
}
