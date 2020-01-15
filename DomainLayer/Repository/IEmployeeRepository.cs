using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository
{
   public interface IEmployeeRepository
    {
        //  List<EmployeeViewModel> GetAllEmployee();

        EmployeeViewModel GetAllEmployees(int currentPage);
        EmployeeViewModel GetEmployee(int EmployeeId);
        EmployeeViewModel CreateEmp(EmployeeViewModel modal);

        void DeleteEmp(int EmployeeId);
    }
}
