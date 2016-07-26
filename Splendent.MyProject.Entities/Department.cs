using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Splendent.MyProject.Entities
{
    public class Department
    {
        #region " Public Property "

        [Required]
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }

        #endregion
    }
}
