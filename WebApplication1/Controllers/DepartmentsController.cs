using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTOs.Departments;
using WebApplication1.Modle;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Departments = context.Departments.Select(
                x => new GetAllDepatmentDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                }
            );
            return Ok(Departments);
        }
        [HttpPost("Create")]
        public IActionResult Create(CreateDepartmentDTO DTO)
        {
            Department department = new Department()
            {
                Name = DTO.Name,
            };
            context.Departments.Add(department);
            context.SaveChanges();
            GetAllDepatmentDTO Get = new GetAllDepatmentDTO()
            {
                Id = department.Id,
                Name = department.Name,
            };

            return Ok(Get);
        }
        [HttpGet("Get")]
        public IActionResult Get(int Id)
        {
            var Department = context.Departments.Find(Id);
            if (Department is null)
            {
                return NotFound();
            }
            GetAllDepatmentDTO dep = new GetAllDepatmentDTO()
            {
                Id = Department.Id,
                Name = Department.Name,

            };
            return Ok(dep);
        }
        [HttpPut("Update")]
        public IActionResult Update(int Id, CreateDepartmentDTO DTO)
        {
            var DepartmentB = context.Departments.Find(Id);
            if (DepartmentB is null)
            {
                return NotFound();
            }
            var DepartmentA = new Department()
            {
                Name = DTO.Name,
            };
            DepartmentB.Name = DepartmentA.Name;
            context.SaveChanges();
            var aa = new GetAllDepatmentDTO()
            {
                Id = DepartmentB.Id,
                Name = DepartmentB.Name,
            };
            return Ok(aa);
        }
        [HttpDelete("Remove")]
        public IActionResult Remove(int Id)
        {
            var Department = context.Departments.Find(Id);
            if (Department is null)
            {
                return NotFound();
            }
            context.Departments.Remove(Department);
            context.SaveChanges();
            return Ok("Success");

        }
    }
}
