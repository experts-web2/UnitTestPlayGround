using Domain.BL.Services.GenericService;
using Domain.BL.Services.Interfaces;
using Domain.Entities.Dtos;
using Domain.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
           var getDepartment = _departmentService.GetAll().ToList();
            return Ok(getDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDto departmentDto)
        {
            var Department =await _departmentService.CreateAsync(departmentDto);
            return Ok(Department);
        }

        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentDto departmentDto)
        {
            var DepartmentDto = _departmentService.Update(departmentDto);
            return Ok(DepartmentDto);
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int Id)
        {
            _departmentService.Delete(Id);
            return Ok("Deleted");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdDepartment(int Id)
        {
           var department = await _departmentService.GetByIdAsync(Id);
            return Ok(department);
        }
    }
}
