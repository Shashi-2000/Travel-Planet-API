using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPIAss1.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        //[StringLength(20), Required]
        public string Name { get; set; }
        //[Range(10, 60)]
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        //[RegularExpression(@"^\d{10}$")]
        public Nullable<decimal> MobileNumber { get; set; }
    }
}