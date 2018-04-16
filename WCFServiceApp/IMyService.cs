using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceApp.Models;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<Employee> GetAllUser();

        [OperationContract]
        int AddUser(Employee objEmployee);

        [OperationContract]
        Employee GetAllUserById(int id);

        [OperationContract]
        int UpdateUser(Employee objEmployee);

        [OperationContract]
        int DeleteUserById(int Id);
    }
}
