using Domain.BL.Services.GenericService;
using Domain.BL.Services.Interfaces;
using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.Implemention
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        public DepartmentService(IGenericRepository<Department> repository) : base(repository)
        {
        }

       
    }

}
