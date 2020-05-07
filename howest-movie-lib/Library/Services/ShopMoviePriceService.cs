using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

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

        public ShopMoviePrice GetShopMoviePrice(int movieId)
        {
            var results = (shopMoviePrice.Where(c => c.MovieId == movieId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<ShopMoviePrice> GetAll()
        {
            return shopMoviePrice;
        }
        public void Add(ShopMoviePrice newShopMoviePrice)
        {
            db.ShopMoviePrice.Add(newShopMoviePrice);
            db.SaveChanges();
        }

        public void Update(ShopMoviePrice updShopMoviePrice)
        {
            db.ShopMoviePrice.Update(updShopMoviePrice);
            db.SaveChanges();
        }

        public void Delete(ShopMoviePrice delShopMoviePrice)
        {
            if (delShopMoviePrice != null)
            {
                db.ShopMoviePrice.Remove(delShopMoviePrice);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<ShopMoviePrice> shopMoviePrices)
        {
            db.ShopMoviePrice.RemoveRange(shopMoviePrices);
            db.SaveChanges();
        }
    }
}