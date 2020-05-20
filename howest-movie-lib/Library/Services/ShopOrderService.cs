using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;
using System;
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

        public ShopOrder GetShopOrder(long orderId)
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
        public long Add(long customerId, DateTime orderDate, string street,
                        string city, string postalCode, string Country)
        {
            var order = db.ShopOrder.Add(new ShopOrder
            {
                CustomerId = customerId,
                OrderDate = orderDate,
                Street = street,
                City = city,
                PostalCode = postalCode,
                Country = Country,
            });
            db.SaveChanges();
            return order.Entity.Id;
        }

        public void Update(ShopOrder updShopOrder)
        {
            db.ShopOrder.Update(updShopOrder);
            db.SaveChanges();
        }

        public void Delete(long orderId)
        {
            new ShopOrderDetailService().Delete(orderId);
            db.ShopOrder.Remove(
                GetShopOrder(orderId)
            );
            db.SaveChanges();
        }
        public void DeleteMultiple(List<long> orderIds)
        {
            foreach (long id in orderIds)
                Delete(id);
            db.SaveChanges();
        }
    }
}