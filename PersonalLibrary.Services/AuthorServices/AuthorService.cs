using PersonalLibrary.Data;
using PersonalLibrary.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.AuthorServices
{
    public class AuthorService
    {
        public bool CreateAuthor(AuthorCreate newAuthor)
        {
            var entity =
                new Author()
                {
                    AuthorId = newAuthor.AuthorId,
                    FirstName = newAuthor.FirstName,
                    LastName = newAuthor.LastName,
                    BirthDate = newAuthor.BirthDate,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuthorListDetail> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Authors
                    .Select(a => new AuthorListDetail
                    {
                        AuthorId = a.AuthorId,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        //              Books = a.Books
                    });
                return query.ToArray();
            }
        }
        public AuthorDetail GetAuthorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Authors.SingleOrDefault(a => a.AuthorId == id);
                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        BirthDate = entity.BirthDate,
                        //        Books = entity.Books
                    };
            }
        }
        public bool UpdateAuthor(AuthorEdit author, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldAuthor = ctx.Authors.Find(id);
                if (oldAuthor == null)
                    return false;

                oldAuthor.FirstName = author.FirstName;
                oldAuthor.LastName = author.LastName;

                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteAuthor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldAuthor = ctx.Authors.Find(id);
                if (oldAuthor == null)
                    return false;

                ctx.Authors.Remove(oldAuthor);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
