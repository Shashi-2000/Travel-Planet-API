using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAss1.Repository.RepHotel;

namespace WebAPIAss1.Controllers
{
    [EnableCors(origins : "*", headers : "*", methods : "*")]
    public class HotelDetController : ApiController
    {
        public readonly IHotelDetail ihotelDetail;
        public HotelDetController() { }
        public HotelDetController(IHotelDetail ihotelDetail)
        {
            this.ihotelDetail = ihotelDetail;
        }

        [Route("api/HotelDet/Hotels")]
        [HttpGet]
        public IHttpActionResult GetHotelDetails()
        {
            var hotelList = ihotelDetail.getHotelDetails();
            if(hotelList.Count == 0)
            {
                return NotFound();
            }
            return Ok(hotelList);
        }
    }
}
