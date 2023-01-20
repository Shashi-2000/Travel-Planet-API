using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAss1.Models;
using WebAPIAss1.Repository.RepHotel;

namespace WebAPIAss1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HotelResController : ApiController
    {
        public readonly IHotelRes iHotelResl;
        public HotelResController() { }
        public HotelResController(IHotelRes iHotelResl)
        {
            this.iHotelResl = iHotelResl;
        }

        [Route("api/HotelRes/GetRes")]
        [HttpGet]
        public IHttpActionResult GetAllRes()
        {
            var resList = iHotelResl.getAll();
            if(resList == null)
            {
                return NotFound();
            }
            return Ok(resList);
        }

        [Route("api/HotelRes/Post")]
        [HttpPost]
        public IHttpActionResult PostData(HotelModel newEntry)
        {
            var status = iHotelResl.PostData(newEntry);
            if(status == true)
            {
                return Ok(status);
            }
            return BadRequest("Data Not Entered");
        }

        [Route("api/HotelRes/Delete/{reservID}")]
        [HttpDelete]
        public IHttpActionResult DeleteData(int reservID)
        {
            var status = iHotelResl.DeleteData(reservID);
            if(status == true)
            {
                return Ok(status);
            }
            return BadRequest();
        }

        [Route("api/HotelRes/Update")]
        [HttpPut]
        public IHttpActionResult UpdatedData(HotelModel updateEntry)
        {
            var status = iHotelResl.UpdatedData(updateEntry);
            if(status == true)
            {
                return Ok(status);
            }
            return BadRequest();
        }
    }
}
