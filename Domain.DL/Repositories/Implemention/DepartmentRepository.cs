using Domain.DL.ApplicationDbContext;
using Domain.DL.Repositories.Abstraction;
using Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DL.Repositories.Implemention
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Department Add(Department item)
        {
            throw new NotImplementedException();
        }

        public void deletebyid(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Department item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> Get(Expression<Func<Department, bool>> predicate, params Expression<Func<Department, object>>[] includes)
        {
            throw new NotImplementedException();
        }

      
    }
}
