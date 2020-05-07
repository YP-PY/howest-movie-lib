using System;
using System.Collections.Generic;

namespace howest_movie_lib.Library.Models
{
    public partial class ShopOrder
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
