using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T> where T : class
    {
        //CRUD Operations
    
        //Create
        void Add(T entity);
        //Read
        IEnumerable<T> GetAll();
        T GetByID(short id);
        //Update
        void Update(T entity);
        //Delete
        void DeleteByID(short id);

    }
}
