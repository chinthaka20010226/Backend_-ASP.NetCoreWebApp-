using employee_crud_.Interfaces.Services;
using employee_crud_.Models.Entities;
using employee_crud_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_crud_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IDepartmentService departmentService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Id must be greater than 0");
                }

                var department = await departmentService.GetDepartmentById(id);
                return Ok(department);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var department = departmentService.GetDepartments();
                return Ok(department);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertDepartment(Department department)
        {
            try
            {
                var _department = departmentService.InsertDepartment(department);
                return Ok(_department);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }

        }

        [HttpPut("{id:int")]
        public async Task<IActionResult> UpdateDepartment(Department department, int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Id must be greater than 0");
                }
                if(department.Id != id)
                {
                    return BadRequest("Id in body must be match id in route ");
                }

                var _department = departmentService.UpdateDepartment(department);
                return Ok(_department);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Id must be greater than 0");
                }

                var department = departmentService.DeleteDepartment(id);
                return Ok(department);
            }
            catch(InvalidAgrumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }
    }
}
