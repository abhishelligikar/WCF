using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFMVCApp.Models
{
    public class EmployeeUser
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpCode { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
    }
}