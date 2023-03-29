using BusinessLayer_.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_.Concrete
{
    public class EmployeeManager:IEmployeeService
    {
        IEmployee _employee;
        public EmployeeManager(IEmployee employee)
        {
            _employee = employee;
        }

        public void EmployeeAdd(Employee employee)
        {
            _employee.Add(employee);
        }

        public void EmployeeDeleteByID(short id)
        {
            _employee.DeleteByID(id);
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employee.Update(employee);
        }

        public Employee EmployeeGetByID(short id)
        {
            return _employee.GetByID(id);
        }

        public IEnumerable<Employee> EmployeeGetList()
        {
            return _employee.GetAll();
        }
    }
}
