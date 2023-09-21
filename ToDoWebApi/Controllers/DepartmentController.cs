using Domain.BL.Services.GenericService;
using Domain.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _entityService;

        public DepartmentController(IService<Department> entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
           var getDepartment = _entityService.GetAll().ToList();
            return Ok(getDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            var Department =await _entityService.CreateAsync(department);
            return Ok(Department);
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            var Department = _entityService.Update(department);
            return Ok(Department);
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int Id)
        {
             _entityService.Delete(Id);
            return Ok("Deleted");
        }
    }
}
