using DataLayerLogic;
using DomainLayer.Model;
using DomainLayer.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using City = DataLayerLogic.City;
using CrudDemoDBEntities = DataLayerLogic.CrudDemoDBEntities;
using Department = DataLayerLogic.Department;

namespace CrudDemo.Controllers
{
    public class EmployeementController : Controller
    {
        private IEmployeeRepository _repo;
        public EmployeementController(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        // GET: Employeement
        public ActionResult Index()
        {
            return View(_repo.GetAllEmployees(1));
        }
        [HttpPost]
        public ActionResult Index(int currentPageIndex)
        {
            return View(_repo.GetAllEmployees(1));
        }


        public ActionResult CreateEdit(int EmployeeId = 0)
        {
            var blogpost = _repo.GetEmployee(EmployeeId);
            CrudDemoDBEntities db = new CrudDemoDBEntities();
            List<City> citylist = db.Cities.ToList();
            ViewBag.cityList = new SelectList(citylist, "CityId", "CityName");
            return View(blogpost);
            //CrudDemoDBEntities db = new CrudDemoDBEntities();

            //List<SelectListItem> listOfDeparts = new List<SelectListItem>();
            //foreach (Department dept in db.Departments)
            //{
            //    SelectListItem selectList = new SelectListItem()
            //    {
            //        Text = dept.DepartmentName,
            //        Value = dept.DepartmentId.ToString(),
            //        Selected = dept.IsActive
            //    };
            //    listOfDeparts.Add(selectList);
            //}
            //EmployeeViewModel customerModel = new EmployeeViewModel();
            //customerModel.Departs = listOfDeparts;

            //List<City> citylist = db.Cities.ToList();
            //ViewBag.cityList = new SelectList(citylist, "CityId", "CityName");

            //if (EmployeeId > 0)
            //{
            //    //Employee emp = from x in db.Employees
            //    //               join y in db.Ci on x.EmpId equals y.Countryid into ps
            //    //               from p in ps
            //    //               select new { x.is, x.name, x.countryid, p.countryname }

            //    Employee emp = db.Employees.SingleOrDefault(x => x.EmpId == EmployeeId && x.IsActive == true);
            //    customerModel.EmpId = emp.EmpId;
            //    customerModel.DepartmentId = emp.DepartmentId;
            //    customerModel.Name = emp.Name;
            //    customerModel.Address = emp.Address;

            //    customerModel.Gender = emp.Gender;
            //    customerModel.DOB = emp.DOB;
            //    customerModel.CityId = emp.CityId;
            //    customerModel.IsActive = emp.IsActive;

            //}
            //return View(customerModel);
        }

        [HttpPost]
        public ActionResult CreateEdit(EmployeeViewModel model)
        {
            CrudDemoDBEntities db = new CrudDemoDBEntities();
            List<Department> deptlist = db.Departments.ToList();
            ViewBag.DepartmentList = new SelectList(deptlist, "DepartmentId", "DepartmentName");

            List<City> citylist = db.Cities.ToList();
            ViewBag.cityList = new SelectList(citylist, "CityId", "CityName");
            if (ModelState.IsValid)
            {
                _repo.CreateEmp(model);
                return RedirectToAction("Index");
            }

            return View(model);
            //try
            //{
            //    CrudDemoDBEntities db = new CrudDemoDBEntities();
            //    List<Department> deptlist = db.Departments.ToList();
            //    ViewBag.DepartmentList = new SelectList(deptlist, "DepartmentId", "DepartmentName");

            //    List<City> citylist = db.Cities.ToList();
            //    ViewBag.cityList = new SelectList(citylist, "CityId", "CityName");

            //    if (model.EmpId > 0)
            //    {
            //        //update
            //        Employee emp = db.Employees.SingleOrDefault(x => x.EmpId == model.EmpId && x.IsActive == true);
            //        emp.Name = model.Name;
            //        emp.Gender = model.Gender;
            //        emp.DOB = model.DOB;
            //        emp.Address = model.Address;
            //        emp.CityId = model.CityId;
            //        emp.DepartmentId = model.DepartmentId;
            //        emp.IsActive = model.IsActive;
            //        db.SaveChanges();


            //        //Employee emp = new Employee();
            //        //emp.Address = model.Address;
            //        //emp.Name = model.Name;
            //        //emp.DepartmentId = model.DepartmentId;

            //        //db.Employees.Add(emp);
            //        //db.SaveChanges();

            //        //int latestEmpId = emp.EmployeeId;


            //        //Site site = new Site();
            //        //site.SiteName = model.SiteName;
            //        //site.EmployeeId = latestEmpId;

            //        //db.Sites.Add(site);
            //        //db.SaveChanges();

            //    }
            //    else
            //    {
            //        //Insert
            //        Employee emp = new Employee();
            //        emp.Name = model.Name;
            //        emp.Gender = model.Gender;
            //        emp.DOB = model.DOB;
            //        emp.Address = model.Address;
            //        emp.CityId = model.CityId;

            //        emp.DepartmentId = model.DepartmentId;
            //        emp.IsActive = model.IsActive;
            //        db.Employees.Add(emp);
            //        db.SaveChanges();

            //    }
            //    return View(model);

            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}

        }

        public ActionResult DeleteEmployee(int EmployeeId)
        {
            _repo.DeleteEmp(EmployeeId);
            return RedirectToAction("Index");

        }
    }
}