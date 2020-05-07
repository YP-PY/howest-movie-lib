using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;

namespace howest_movie_lib.Library.Services
{
    public class ShopCustomerService
    {
        db_moviesContext db = new db_moviesContext();
        DbSet<ShopCustomer> shopCustomer;
        public ShopCustomerService()
        {
            this.shopCustomer = db.ShopCustomer;
        }

        public ShopCustomer GetShopCustomer(int id)
        {
            var results = (shopCustomer.Where(c => c.Id == id));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<ShopCustomer> GetAll()
        {
            return shopCustomer;
        }
        public void Add(ShopCustomer newShopCustomer)
        {
            db.ShopCustomer.Add(newShopCustomer);
            db.SaveChanges();
        }

        public void Update(ShopCustomer updShopCustomer)
        {
            db.ShopCustomer.Update(updShopCustomer);
            db.SaveChanges();
        }

        public void Delete(ShopCustomer delShopCustomer)
        {
            if (delShopCustomer != null)
            {
                db.ShopCustomer.Remove(delShopCustomer);
                db.SaveChanges();
            }
        }
        public void DeleteMultiple(List<ShopCustomer> shopCustomers)
        {
            db.ShopCustomer.RemoveRange(shopCustomers);
            db.SaveChanges();
        }
    }
}