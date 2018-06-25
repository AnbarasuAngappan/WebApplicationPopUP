using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationPopUP.Models
{
    [Table("[Popupemployee]")]
    public class Employee
    {
        //public int id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }      
        [Required(ErrorMessage = "Employee ID is required")]
        [Display(Name = "ID :")]
        string _employeeID = "IBOT";
        public string EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
            }
        }

        [Required(ErrorMessage = "Employee Name is required")]
        [Display(Name = "Employee Name :")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee Age is required")]
        [Display(Name = "Employee Age :")]
        public string EmployeeAge { get; set; }

        [Required(ErrorMessage = "Employee Gender is required")]
        [Display(Name = "Employee Gender :")]
        public string EmployeeGender { get; set; }

        [Required(ErrorMessage = "Employee City id required")]
        [Display(Name = "Employee City :")]
        public string EmployeeCity { get; set; }

        [Display(Name = "Employee Department ID :")]
        public string EmpDepartmentID { get; set; }

        [Display(Name = "Department ID :")]
        public string DepartmentID { get; set; }

    }
}