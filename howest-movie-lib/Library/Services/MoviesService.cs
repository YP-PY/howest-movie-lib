using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class MoviesService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<Movies> movies;

        public MoviesService()
        {
            this.movies = db.Movies;
        }

        public Movies GetMovies(long id)
        {
            var results = (movies.Where(c => c.Id == id));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<Movies> GetAll()
        {
            return movies;
        }
        public void Add(Movies newMovies)
        {
            db.Movies.Add(newMovies);
            db.SaveChanges();
        }

        public void Update(Movies updMovies)
        {
            db.Movies.Update(updMovies);
            db.SaveChanges();
        }

        public void Delete(Movies delMovies)
        {
            if (delMovies != null)
            {
                db.Movies.Remove(delMovies);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<Movies> movies)
        {
            db.Movies.RemoveRange(movies);
            db.SaveChanges();
        }
    }
}