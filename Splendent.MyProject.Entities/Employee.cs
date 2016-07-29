using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Splendent.MyProject.Entities
{
    public class Employee
    {
        #region " Public Property "

        [Required]
        public int EmployeeID { get; set; }
        [Required, StringLength(20, ErrorMessage = "First Name should be less than 20 charactor")]
        //[Remote("IsEmployeeNameExists", "Employee", ErrorMessage = "Employee Name already Exists")]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(20)]
        public string State { get; set; }
        [StringLength(15)]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }
        //[StringLength(100)]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        public int? DepartmentID { get; set; }
        
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
             
        #endregion

        public string EmployeeName
        {
            get { return string.Concat(FirstName.ToString() + " " + LastName.ToString()); }
        }

    }
}
