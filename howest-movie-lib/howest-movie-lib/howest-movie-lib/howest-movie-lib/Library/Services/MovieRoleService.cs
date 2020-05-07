using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class MovieRoleService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<MovieRole> movieRole;
        public MovieRoleService()
        {
            this.movieRole = db.MovieRole;
        }

        public MovieRole GetMovieRole(int movieId, int personId)
        {
            var results = (movieRole.Where(c => c.MovieId == movieId && c.PersonId == personId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<MovieRole> GetAll()
        {
            return movieRole;
        }
        public void Add(MovieRole newMovieRole)
        {
            db.MovieRole.Add(newMovieRole);
            db.SaveChanges();
        }

        public void Update(MovieRole updMovieRole)
        {
            db.MovieRole.Update(updMovieRole);
            db.SaveChanges();
        }

        public void Delete(MovieRole delMovieRole)
        {
            if (delMovieRole != null)
            {
                db.MovieRole.Remove(delMovieRole);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<MovieRole> movieRoles)
        {
            db.MovieRole.RemoveRange(movieRoles);
            db.SaveChanges();
        }
    }
}