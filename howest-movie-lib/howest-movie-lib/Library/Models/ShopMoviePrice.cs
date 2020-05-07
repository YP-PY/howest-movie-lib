using System;
using System.Collections.Generic;

namespace howest_movie_lib.Library.Models
{
    public partial class ShopMoviePrice
    {
        public long MovieId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
