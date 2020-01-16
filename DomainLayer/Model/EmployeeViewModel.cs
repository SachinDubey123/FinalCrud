using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainLayer.Model
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public int Gender { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        public System.DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Select a city.")]
        public int CityId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        public string CityName { get; set; }

        public string DepartmentName { get; set; }

        public List<Employee> EMployees { get; set; }
        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
        public IEnumerable<SelectListItem> Departs { get; set; }

        public IEnumerable<SelectListItem> CitiesList { get; set; }

        public IEnumerable<string> SelectedDeparts { get; set; }

    }
}
