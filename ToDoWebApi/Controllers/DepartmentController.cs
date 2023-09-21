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
           var getDepartment = _entityService.GetAllAsync().ToList();
            return Ok(getDepartment);
        }
    }
}
