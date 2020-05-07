using System;
using System.Collections.Generic;

namespace howest_movie_lib.Library.Models
{
    public partial class ShopCustomer
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
