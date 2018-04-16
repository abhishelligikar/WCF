using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceApp.Models;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        //private WCFServiceEntities db = new WCFServiceEntities();
        public void DoWork()
        {
        }

        public List<Employee> GetAllUser()
        {
            List<Employee> userlst = new List<Employee>();
            using (WCFServiceEntities tstDb = new WCFServiceEntities())
            {
                var lstUsr = from k in tstDb.Employees select k;
                foreach (var item in lstUsr)
                {
                    Employee usr = new Employee();
                    usr.EmployeeID = item.EmployeeID;
                    usr.FirstName = item.FirstName;
                    usr.LastName = item.LastName;
                    usr.EmpCode = item.EmpCode;
                    usr.Position = item.Position;
                    usr.Office = item.Office;
                    userlst.Add(usr);

                }
                return userlst;
            }
        }
        
        public Employee GetAllUserById(int id)
        {
            using (WCFServiceEntities tstDb = new WCFServiceEntities())
            {
                var lstUsr = from k in tstDb.Employees where k.EmployeeID == id select k;
                Employee usr = new Employee();
                foreach (var item in lstUsr)
                {
                    usr.EmployeeID = item.EmployeeID;
                    usr.FirstName = item.FirstName;
                    usr.LastName = item.LastName;
                    usr.Position = item.Position;
                    usr.Office = item.Office;
                }
                return usr;
            }
                
        }

        public int DeleteUserById(int Id)
        {

            using (WCFServiceEntities tstDb = new WCFServiceEntities())
            {
                Employee usrdtl = new Employee();
                usrdtl.EmployeeID = Id;
                tstDb.Entry(usrdtl).State = EntityState.Deleted;
                int Retval = tstDb.SaveChanges();
                return Retval;

            }
           
        }

        public int AddUser(Employee objEmployee)
        {
            using (WCFServiceEntities tstDb = new WCFServiceEntities())
            {
                Employee usrdtl = new Employee();
                usrdtl.EmployeeID = objEmployee.EmployeeID;
                usrdtl.FirstName = objEmployee.FirstName;
                usrdtl.LastName = objEmployee.LastName;
                usrdtl.EmpCode = objEmployee.EmpCode;
                usrdtl.Position = objEmployee.Position;
                usrdtl.Office = objEmployee.Office;
                tstDb.Employees.Add(usrdtl);
                int Retval = tstDb.SaveChanges();
                return Retval;
            }
        }

        public int UpdateUser(Employee objEmployee)
        {
            using (WCFServiceEntities tstDb = new WCFServiceEntities())
            {
                Employee usrdtl = new Employee();
                usrdtl.EmployeeID = objEmployee.EmployeeID;
                usrdtl.FirstName = objEmployee.FirstName;
                usrdtl.LastName = objEmployee.LastName;
                usrdtl.Position = objEmployee.Position;
                usrdtl.Office = objEmployee.Office;
                tstDb.Entry(usrdtl).State = EntityState.Modified;

                int Retval = tstDb.SaveChanges();
                return Retval;
            }
        }

    }
}
