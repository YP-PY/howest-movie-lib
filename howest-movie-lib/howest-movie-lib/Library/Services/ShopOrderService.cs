using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class ShopOrderService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<ShopOrder> shopOrder;
        public ShopOrderService()
        {
            this.shopOrder = db.ShopOrder;
        }

        public ShopOrder GetShopOrder(int orderId)
        {
            var results = (shopOrder.Where(c => c.Id == orderId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<ShopOrder> GetAll()
        {
            return shopOrder;
        }
        public void Add(ShopOrder newShopOrder)
        {
            db.ShopOrder.Add(newShopOrder);
            db.SaveChanges();
        }

        public void Update(ShopOrder updShopOrder)
        {
            db.ShopOrder.Update(updShopOrder);
            db.SaveChanges();
        }

        public void Delete(ShopOrder delShopOrder)
        {
            if (delShopOrder != null)
            {
                db.ShopOrder.Remove(delShopOrder);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<ShopOrder> shopOrders)
        {
            db.ShopOrder.RemoveRange(shopOrders);
            db.SaveChanges();
        }
    }
}