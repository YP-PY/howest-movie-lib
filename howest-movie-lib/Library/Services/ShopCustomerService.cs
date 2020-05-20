using howest_movie_lib.Library.Models;
using System.Collections.Generic;
using System.Linq; // linq extension methods
using Microsoft.EntityFrameworkCore;
using howest_movie_lib.Library.Exceptions;
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

        public ShopCustomer GetShopCustomer(long id)
        {
            var results = (shopCustomer.Where(c => c.Id == id));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public ShopCustomer GetShopCustomer(string aspnetId)
        {
            var results = (shopCustomer.Where(c => c.UserId == aspnetId));
            if (results.Count() == 0)
                return null;
            return results.First();
        }
        public IEnumerable<ShopCustomer> GetAll()
        {
            return shopCustomer;
        }
        public long Add(string aspNetId, string name, string street,
        string city, string postalcode, string country)
        {
            var customerList = shopCustomer.ToList();
            foreach (var customer in customerList)
                if (customer.UserId.Equals(aspNetId))
                    throw new CustomerException("customer already exists");
            var addedcustomer = db.ShopCustomer.Add(new ShopCustomer
            {
                UserId = aspNetId,
                Name = name,
                Street = street,
                City = city,
                PostalCode = postalcode,
                Country = country
            });
            
            db.SaveChanges();
            return addedcustomer.Entity.Id;
        }
        public void Update(long id, string aspNetId, string name, string street,
        string city, string postalcode, string country)
        {
            db.ShopCustomer.Update(new ShopCustomer
            {
                Id = id,
                UserId = aspNetId,
                Name = name,
                Street = street,
                City = city,
                PostalCode = postalcode,
                Country = country
            });
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