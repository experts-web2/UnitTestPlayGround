using Domain.BL.Services.GenericService;
using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Dtos;
using Domain.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.Interfaces
{
    public interface IDepartmentService 
    {
        Task<DepartmentDto> GetByIdAsync(int id);
        List<DepartmentDto> GetAll();
        Task<DepartmentDto> CreateAsync(DepartmentDto entDepartmentDtoity);
        DepartmentDto Update(DepartmentDto entity);
        void Delete(int id);
    }
}
