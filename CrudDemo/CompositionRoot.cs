using CrudDemo.Controllers;
using DomainLayer.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudDemo
{
    public class CompositionRoot
    {
        private readonly IControllerFactory _controllerFactory;

        public CompositionRoot()
        {
            this._controllerFactory = CompositionRoot.CreateControllerFactory();
        }

        public IControllerFactory ControllerFactory
        {
            get
            {
                return _controllerFactory;
            }
        }

        private static IControllerFactory CreateControllerFactory()
        {
            string blogRepositoryTypeName = ConfigurationManager.AppSettings["EmployeeRepositoryType"];
            var blogRepositoryType = Type.GetType(blogRepositoryTypeName, true);
            var repository = (IEmployeeRepository)Activator.CreateInstance(blogRepositoryType);

            var controllerFactory = new MainController(repository);
            return controllerFactory;
        }
    }
}