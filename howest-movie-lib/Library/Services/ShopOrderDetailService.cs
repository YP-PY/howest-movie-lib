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

        public ShopOrderDetail GetShopOrderDetail(long movieId, long orderId)
        {
            var results = (shopOrderDetail.Where(c => c.MovieId == movieId && c.OrderId == orderId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<ShopOrderDetail> GetAll()
        {
            return shopOrderDetail;
        }
        public void Add(ShopOrderDetail newShopOrderDetail)
        {
            db.ShopOrderDetail.Add(newShopOrderDetail);
            db.SaveChanges();
        }

        public void Update(ShopOrderDetail updShopOrderDetail)
        {
            db.ShopOrderDetail.Update(updShopOrderDetail);
            db.SaveChanges();
        }

        public void Delete(ShopOrderDetail delShopOrderDetail)
        {
            if (delShopOrderDetail != null)
            {
                db.ShopOrderDetail.Remove(delShopOrderDetail);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<ShopOrderDetail> shopOrderDetails)
        {
            db.ShopOrderDetail.RemoveRange(shopOrderDetails);
            db.SaveChanges();
        }
    }
}