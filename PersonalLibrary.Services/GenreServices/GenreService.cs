using PersonalLibrary.Data;
using PersonalLibrary.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibrary.Services.GenreServices
{
    public class GenreService
    {
        public bool CreateGenre(GenreCreate genre)
        {
            var entity = new Genre
            {
                GenreType = genre.GenreType
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
        public IEnumerable<GenreListDetail> GetAllGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Genres
                    .Select(g => new GenreListDetail
                    {
                        Id = g.Id,
                        GenreType = g.GenreType
                    }).ToList();

                return query;
            }
        }
        public GenreDetail GetAllGenresById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var genre =
                    ctx
                    .Genres
                    .SingleOrDefault(g => g.Id == id);

                if (genre == null)
                {
                    return null;
                }
                return new GenreDetail
                {
                    Id = genre.Id,
                    GenreType = genre.GenreType
                    //      ListOfBooks = genre.ListOfBooks,
                };
            }
        }
        public GenreDetail GetAllGenresByGenreType(string genreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var genre =
                    ctx
                    .Genres
                    .SingleOrDefault(g => g.GenreType == genreType);
                if (genre == null)
                {
                    return null;
                }
                return new GenreDetail
                {
                    Id = genre.Id,
                    GenreType = genre.GenreType
                    //         ListOfBooks = genre.ListOfBooks,
                };
            }
        }
        public bool UpdateGenre(GenreEdit genre, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenre = ctx.Genres.Find(id);
                if (oldGenre == null)
                {
                    return false;
                }
                oldGenre.GenreType = genre.GenreType;

                return ctx.SaveChanges() > 0;
            }
        }
        public bool DeleteGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenre = ctx.Genres.Find(id);
                if (oldGenre == null)
                {
                    return false;
                }
                ctx.Genres.Remove(oldGenre);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}

