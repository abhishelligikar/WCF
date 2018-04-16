using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFMVCApp.Models;
using WCFMVCApp.ServiceReference1;

namespace WCFMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        ServiceReference1.MyServiceClient ur = new ServiceReference1.MyServiceClient();

        [HttpGet]
        public ActionResult Index()
        {
            List<EmployeeUser> lstRecord = new List<EmployeeUser>();

            var lst = ur.GetAllUser();

            foreach (var item in lst)
            {
                EmployeeUser usr = new EmployeeUser();
                usr.EmployeeID = item.EmployeeID;
                usr.FirstName = item.FirstName;
                usr.LastName = item.LastName;
                usr.EmpCode = item.EmpCode;
                usr.Position = item.Position;
                usr.Office = item.Office;
                lstRecord.Add(usr);
            }
            return View(lstRecord);
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeUser mdl)
        {
            Employee usr = new Employee();
            usr.EmployeeID = mdl.EmployeeID;
            usr.FirstName = mdl.FirstName;
            usr.LastName = mdl.LastName;
            usr.EmpCode = mdl.EmpCode;
            usr.Position = mdl.Position;
            usr.Office = mdl.Office;
            ur.AddUser(usr);
            return RedirectToAction("Index", "Employee");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            int retval = ur.DeleteUserById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lst = ur.GetAllUserById(id);
            EmployeeUser usr = new EmployeeUser();
            usr.EmployeeID = lst.EmployeeID;
            usr.FirstName = lst.FirstName;
            usr.LastName = lst.LastName;
            usr.EmpCode = lst.EmpCode;
            usr.Position = lst.Position;
            usr.Office = lst.Office;
            return View(usr);

        }

        [HttpPost]
        public ActionResult Edit(EmployeeUser mdl)
        {
            Employee usr = new Employee();
            usr.EmployeeID = mdl.EmployeeID;
            usr.FirstName = mdl.FirstName;
            usr.LastName = mdl.LastName;
            usr.EmpCode = mdl.EmpCode;
            usr.Position = mdl.Position;
            usr.Office = mdl.Office;
            int Retval = ur.UpdateUser(usr);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}