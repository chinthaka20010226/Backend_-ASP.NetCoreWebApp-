using employee_crud_.Interfaces.Repositories;
using employee_crud_.Interfaces.Services;
using employee_crud_.Models.Entities;

namespace employee_crud_.Services
{
    public class EmployeeService(IEmployeeRepository employees) : IEmployeeService
    {
        public async Task<Employee> GetEmployeeById(int id)
        {
            if(id <= 0)
            {
                throw new InvalidArgumentException("must bo grater than 0");
            }

            var employee = employees.GetEmployeeById(id);

            return await (employee ?? throw new NotFoundException($"Employee with id {id} not found"));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employees.GetEmployees();
        }
    }
}
