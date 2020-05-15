using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;
namespace howest_movie_lib.Library.Services
{
    class GenresService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<Genres> genres;
        public GenresService(){
            this.genres = db.Genres;
        }

        public Genres GetGenre(long id){
            var results = genres.Where(c => c.Id == id);
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<Genres> GetAll(){
            return genres;
        }
        public void Add(Genres newGenre){
            db.Genres.Add(newGenre);
            db.SaveChanges();
        }

        public void Update(Genres updGenre){
            // db.Update(updGenre);
            db.Genres.Update(updGenre);
            db.SaveChanges();
        }
        
        public void Delete(Genres delGenre){
            if (delGenre != null){
                db.Genres.Remove(delGenre);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<Genres> genre)
        {
            db.Genres.RemoveRange(genre);
            db.SaveChanges();
        }
    }
}