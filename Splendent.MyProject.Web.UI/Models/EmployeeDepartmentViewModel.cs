using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Splendent.MyProject.Web.UI.Models
{
    public class EmployeeDepartmentViewModel
    {
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}