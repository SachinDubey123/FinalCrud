//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrudDemo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
    
        public virtual City City { get; set; }
        public virtual Department Department { get; set; }
    }
}
