using DomainLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CrudDemo.Controllers
{
    public class MainController : DefaultControllerFactory
    {
        private readonly Dictionary<string, Func<RequestContext, IController>> _controllermapper;

        public MainController(IEmployeeRepository repo)
        {
            if (repo == null)
            {
                throw new ArgumentException("repo");
            }
            this._controllermapper = new Dictionary<string, Func<RequestContext, IController>>();
            this._controllermapper["Home"] = context => new HomeController();
            this._controllermapper["Employeement"] = context => new EmployeementController(repo);
        }
        // GET: Main
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (this._controllermapper.ContainsKey(controllerName))
            {
                return this._controllermapper[controllerName](requestContext);
            }
            else
            {
                return null;
            }

        }
    }
}