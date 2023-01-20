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
    public class SecondSampleController : ApiController
    {
        public readonly IEmployeeDetails IemployeeDetails;
        public SecondSampleController() { }
        public SecondSampleController(IEmployeeDetails IemployeeDetails)
        {
            this.IemployeeDetails = IemployeeDetails;
        }
        [Route("api/SecondSample/deleteEmployee/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var status = IemployeeDetails.deleteEmployee(id);
            if(status != null)
            {
                return Ok(status);
            }
            return NotFound();
        }
        [Route("api/SecondSample/insertEmployee")]
        [HttpPost]
        public IHttpActionResult InsertEmployee(EmployeeModel newEmployee)
        {
            var status = IemployeeDetails.insertEmployee(newEmployee);
            if(status == "Employee Inserted")
            {
                return Ok();
            }
            return NotFound();
        }
        [Route("api/SecondSample/insertBulkEmployees")]
        [HttpPut]
        public IHttpActionResult InsertBulkEmployees(List<EmployeeModel> employees)
        {
            var status = IemployeeDetails.insertBulkEmployees(employees);
            if(status == "Bulk Employees Inserted")
            {
                return Ok(status);
            }
            return BadRequest(status);
        }

        [Route("api/SecondSample/modifyAge")]
        [HttpPost]
        public IHttpActionResult ModifyAge()
        {
            var status = IemployeeDetails.modifyAgeColumn();
            if(status == "Age Updated")
            {
                return Ok();
            }
            return BadRequest();
        }
        [Route("api/SecondSample/deleteEntireData")]
        [HttpPost]
        public IHttpActionResult DeleteEntireData()
        {
            var status = IemployeeDetails.deleteTableData();
            if(status == "Table Data Erased")
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
