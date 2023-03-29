using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_.Abstract
{
    public interface IEmployeeService
    {
        Employee EmployeeGetByID(short id);
        IEnumerable<Employee> EmployeeGetList();
        void EmployeeAdd(Employee employee);
        void EmployeeDeleteByID(short id);
        void EmployeeUpdate(Employee employee);
      
    }
}
