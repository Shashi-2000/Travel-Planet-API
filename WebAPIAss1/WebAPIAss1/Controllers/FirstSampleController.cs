using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPIAss1.Models;
using WebAPIAss1.Repository;

namespace WebAPIAss1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class FirstSampleController : ApiController
    {
        public readonly IEmployeeDetails iemployeeDetails;
        public FirstSampleController() { }
        public FirstSampleController(IEmployeeDetails employeeDetails)
        {
            iemployeeDetails = employeeDetails;
        }

        [Route("api/FirstSample/GetAllEmployee")]
        [HttpGet]
        public IHttpActionResult GetAllEmployee()
        {
            var list = iemployeeDetails.getAllEmployees();
            if(list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [Route("api/FirstSample/getEmployeeById/{id}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            var employee = iemployeeDetails.getEmployeeByID(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [Route("api/FirstSample/updateEmployee")]
        [HttpPost]
        public IHttpActionResult UpdateEmployee(EmployeeModel employee)
        {
            var udatedList = iemployeeDetails.updateEmployees(employee);
            if (udatedList == "Updated")
            {
                return Ok(udatedList);
            }
            return BadRequest(udatedList);
        }
    }
}
