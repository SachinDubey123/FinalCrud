using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayerLogic.Model
{
    public class EmployeeViewModel1
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
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

        public IEnumerable<string> SelectedDeparts { get; set; }

        public DomainLayer.Model.EmployeeViewModel ToDomainBind()
        {
            return new DomainLayer.Model.EmployeeViewModel
            {
                EmpId = this.EmpId,
                Name = this.Name,
                Address = this.Address,
                Gender = this.Gender,
                CityId = this.CityId,
                DepartmentId = this.DepartmentId,
                IsActive = this.IsActive
            };
        }
    }
}
