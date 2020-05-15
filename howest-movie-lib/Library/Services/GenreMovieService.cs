using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class GenreMovieService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<GenreMovie> genreMovie;
        public GenreMovieService()
        {
            this.genreMovie = db.GenreMovie;
        }

        public List<string> GetGenres(long movieId)
        {
            var results = (genreMovie.Where(c => c.MovieId == movieId));
            if (results.Count() == 0)
                return null;
            GenresService genreService = new GenresService();
            List<string> genres = new List<string>();
            foreach (var genreMovie in results)
            {
                genres.Add(genreService.GetGenre(genreMovie.GenreId).Name);
            }
            return genres;
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