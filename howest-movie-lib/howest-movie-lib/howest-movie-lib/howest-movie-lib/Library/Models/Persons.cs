using System;
using System.Collections.Generic;

namespace howest_movie_lib.Library.Models
{
    public partial class Persons
    {
        public long Id { get; set; }
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }
}
