using PersonalLibrary.Data;
using PersonalLibrary.Models.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.BookServices
{
    public class BookService
    {
        public bool CreateBook(BookCreate book)
        {
            var entity =
                new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Summary = book.Summary,
                    DatePublished = book.DatePublished,
                    AuthorId = book.AuthorId,
                    GenreId = book.GenreId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Books.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BookListDetail> GetBooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Books
                        .Select(
                            b =>
                                new BookListDetail
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    DatePublished = b.DatePublished,
                                    Author = b.Author,
                                    Genre = b.Genre
                                }
                        );
                return query.ToArray();
            }
        }
        public BookDetail GetBookById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Books
                    .SingleOrDefault(b => b.Id == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new BookDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Summary = entity.Summary,
                        BestSeller = entity.BestSeller,
                        DatePublished = entity.DatePublished,
                        Author = ctx.Authors.Find(entity.AuthorId),
                        Genre = ctx.Genres.Find(entity.GenreId)
                    };
            }
        }
        public bool UpdateBook(BookEdit book)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Books
                    .Single(b => b.Id == book.Id);
                entity.Id = book.Id;
                entity.Title = book.Title;
                entity.Summary = book.Summary;
                entity.BestSeller = book.BestSeller;
                entity.DatePublished = book.DatePublished;
                entity.Author = book.Author;
                entity.Genre = book.Genre;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBook(int bookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Books
                    .Single(b => b.Id == bookId);
                ctx.Books.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }   
    }
}
