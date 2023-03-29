
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository : IEmployee
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Add(Employee entity)
        {

            _context.Set<Employee>().Add(entity);
            _context.SaveChanges();
        }

        public void DeleteByID(short id)
        {
            var order = _context.Set<Employee>().SingleOrDefault(x => x.Id == id);
            if (order != null)
            {
                _context.Set<Employee>().Remove(order);
                _context.SaveChanges();
            }
        }
        public IEnumerable<Employee> GetAll()
        {
                return _context.Set<Employee>().ToList();
            }

        public Employee GetByID(short id)
        {
            return _context.Set<Employee>().Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(Employee entity)
        {
            _context.Set<Employee>().Update(entity);
            _context.SaveChanges();
        }
    }
}