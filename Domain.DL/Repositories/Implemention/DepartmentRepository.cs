using Domain.DL.ApplicationDbContext;
using Domain.DL.Repositories.Abstraction;
using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DL.Repositories.Implemention
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
