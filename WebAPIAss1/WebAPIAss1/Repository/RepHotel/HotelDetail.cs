using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAss1.Models;

namespace WebAPIAss1.Repository.RepHotel
{
    public class HotelDetail : IHotelDetail
    {
        Student_AssigEntities conn = new Student_AssigEntities();
        List<HotelDetailsModel> IHotelDetail.getHotelDetails()
        {
            List<HotelDetailsModel> hotelDetail = conn.HotelDetails.Select(e => new HotelDetailsModel()
            {
                HotelName = e.HotelName,
                HotelType = e.HotelType,
                Price = e.Price
            }).ToList<HotelDetailsModel>();
            conn.Dispose();
            return hotelDetail;
        }
    }
}