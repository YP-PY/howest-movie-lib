using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class ShopOrderDetailService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<ShopOrderDetail> shopOrderDetail;
        public ShopOrderDetailService()
        {
            this.shopOrderDetail = db.ShopOrderDetail;
        }

        public IEnumerable<ShopOrderDetail> GetShopOrderDetails(long orderId)
        {
            var results = (shopOrderDetail.Where(c => c.OrderId == orderId));
            if (results.Count() == 0)
                return null;
            return results;
        }
        public IEnumerable<ShopOrderDetail> GetAll()
        {
            return shopOrderDetail;
        }

        public void Add(long orderId, IEnumerable<long> movieIds)
        {
            foreach (var item in movieIds)
                Add(orderId, item);
            db.SaveChanges();
        }
        public void Add(long orderId, long movieId)
        {
            db.ShopOrderDetail.Add(new ShopOrderDetail
            {
                MovieId = movieId,
                OrderId = orderId,
                UnitPrice = new ShopMoviePriceService().GetShopMoviePrice(movieId)
            });
            db.SaveChanges();
        }

        public void Update(ShopOrderDetail updShopOrderDetail)
        {
            db.ShopOrderDetail.Update(updShopOrderDetail);
            db.SaveChanges();
        }

        public void Delete(long orderId)
        {
            db.ShopOrderDetail.RemoveRange(GetShopOrderDetails(orderId));
            db.SaveChanges();
        }
    }
}