using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEmployee:IRepository<Employee> 
    {
        //Since we inherit IRepository, we add all the methods in the generic pool here
    }
}
