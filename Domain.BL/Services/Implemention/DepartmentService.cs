using Domain.BL.Services.Interfaces;
using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Dtos;
using Domain.Entities.Model;

namespace Domain.BL.Services.Implemention
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentService(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<DepartmentDto> CreateAsync(DepartmentDto departmentDto)
        {
            var department = DepartmentEntity(departmentDto);
            await _repository.Add(department);
            _repository.SaveChange();
            return departmentDto;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChange();
        }

        public List<DepartmentDto> GetAll()
        {
            var GetAllDepartment = _repository.GetAll().ToList();
            return GetAllDepartment.Select(DepartmentDto).ToList();
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _repository.GetByID(id);
            return DepartmentDto(department);
        }

        public DepartmentDto Update(DepartmentDto departmentDto)
        {
            var department = DepartmentEntity(departmentDto);
            _repository.update(department);
            _repository.SaveChange();
            return departmentDto;
        }


        private Department DepartmentEntity(DepartmentDto departmentDto)
        {
            var department = new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreatedBy = departmentDto.CreatedBy,
                CreatedDate = departmentDto.CreatedDate,
                ModifiedBy = departmentDto.ModifiedBy,
                ModifiedDate = departmentDto.ModifiedDate
            };

            return department;
        }

        private DepartmentDto DepartmentDto(Department department)
        {
            var departmentDto = new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedDate = department.CreatedDate,
                ModifiedBy = department.ModifiedBy,
                ModifiedDate = department.ModifiedDate
            };


            return departmentDto;
        }
    }

}
