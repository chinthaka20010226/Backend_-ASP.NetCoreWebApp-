using employee_crud_.Interfaces.Repositories;
using employee_crud_.Interfaces.Services;

namespace employee_crud_.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee;

        // Constructor injection of IEmployeeRepository
        public EmployeeService(IEmployeeRepository employee)
        {
            _employee = employee;
        }
    }
}
