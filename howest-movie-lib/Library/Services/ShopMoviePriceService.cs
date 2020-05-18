using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;
using howest_movie_lib.Library.Exceptions;
namespace howest_movie_lib.Library.Services
{
    public class ShopMoviePriceService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<ShopMoviePrice> shopMoviePrice;
        public ShopMoviePriceService()
        {
            this.shopMoviePrice = db.ShopMoviePrice;
        }

        public decimal GetShopMoviePrice(long movieId)
        {
            var results = (shopMoviePrice.Where(c => c.MovieId == movieId));
            if (results.Count() == 0)
                throw new MovieNotFoundException(string.Format("The price of a movie Could not be found."));
            return results.First().UnitPrice;
        }
        public IEnumerable<ShopMoviePrice> GetAll()
        {
            return shopMoviePrice;
        }
        public void Add(long movieId, decimal unitPrice)
        {
            shopMoviePrice.Add(new ShopMoviePrice{
                MovieId = movieId,
                UnitPrice = unitPrice
            });
            db.SaveChanges();
        }
        public bool IsPopulated(){
            return shopMoviePrice.Count() > 0;
        }
        public void Update(long movieId, decimal newPrice)
        {
            shopMoviePrice.Update(new ShopMoviePrice{
                MovieId = movieId,
                UnitPrice = newPrice
            });
            db.SaveChanges();
        }

        public void Delete(ShopMoviePrice delShopMoviePrice)
        {
            if (delShopMoviePrice != null)
            {
                shopMoviePrice.Remove(delShopMoviePrice);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<ShopMoviePrice> shopMoviePrices)
        {
            shopMoviePrice.RemoveRange(shopMoviePrices);
            db.SaveChanges();
        }
    }
}