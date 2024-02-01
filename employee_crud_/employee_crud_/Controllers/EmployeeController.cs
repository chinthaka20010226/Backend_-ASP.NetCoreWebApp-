using employee_crud_.Interfaces.Services;
using employee_crud_.Models.Entities;
using employee_crud_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employee_crud_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(id);
                return Ok(employee);
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
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employee = await _employeeService.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            try
            {
                var _employee = await _employeeService.InsertEmployee(employee);
                return Ok(_employee);
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(Employee employee, int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Id must be greater than 0");
                }

                if(employee.Id != id)
                {
                    return BadRequest("Id in body must match id in route");
                }

                var _employee = await _employeeService.UpdateEmployee(employee);
                return Ok(_employee);
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
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("Id must be greater than 0");
                }

                var employee = await _employeeService.DeleteEmployee(id);
                return Ok(employee);
            }
            catch (InvalidAgrumentException ex)
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
