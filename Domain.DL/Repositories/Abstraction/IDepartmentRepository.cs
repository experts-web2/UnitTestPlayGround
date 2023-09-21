using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DL.Repositories.Abstraction
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        
    }
}
