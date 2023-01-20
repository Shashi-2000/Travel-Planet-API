using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIAss1.Models
{
    public class HotelModel
    {
        public int ReservationID { get; set; }
        public string Hotel { get; set; }
        public Nullable<System.DateTime> Arrival { get; set; }
        public Nullable<System.DateTime> Departure { get; set; }
        public string TYPE { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Guests { get; set; }
    }
}