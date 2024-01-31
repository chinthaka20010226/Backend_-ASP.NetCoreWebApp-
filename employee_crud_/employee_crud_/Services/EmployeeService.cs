using employee_crud_.Interfaces.Repositories;
using employee_crud_.Interfaces.Services;

namespace employee_crud_.Services
{
    public class EmployeeService(IEmployeeService employee) : IEmployeeService
    {
    }
}
