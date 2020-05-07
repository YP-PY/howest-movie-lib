using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class GenreMovieService
    {
        db_moviesContext db = new db_moviesContext();  // <== connected with the database
        DbSet<GenreMovie> genreMovie; // <== empty genreMovie object
        public GenreMovieService()
        {
            this.genreMovie = db.GenreMovie; // <== initialize movie object # I do this because i'm to lazy to write 
        }

        public GenreMovie GetGenreMovie(int movieId, int genreId)
        {
            var results = (genreMovie.Where(c => c.MovieId == movieId && c.GenreId == genreId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }

        public void Add(GenreMovie newGenreMovie)
        {
            db.GenreMovie.Add(newGenreMovie);
            db.SaveChanges();
        }

        public void Update(GenreMovie updGenreMovie)
        {
            db.GenreMovie.Update(updGenreMovie);
            db.SaveChanges();
        }

        public void Delete(GenreMovie delGenreMovie)
        {
            if (delGenreMovie != null)
            {
                db.GenreMovie.Remove(delGenreMovie);
                db.SaveChanges();
            }
        }

        public void DeleteMultiple(List<GenreMovie> genresMovies)
        {
            db.GenreMovie.RemoveRange(genresMovies);
            db.SaveChanges();
        }
    }
}