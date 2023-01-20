using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAss1.Models
{
    public class HotelDetailsModel
    {
        public string HotelName { get; set; }
        public string HotelType { get; set; }
        public Nullable<int> Price { get; set; }
    }
}