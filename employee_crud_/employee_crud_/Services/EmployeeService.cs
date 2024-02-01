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

        public async Task<Employee> InsertEmployee(Employee employee)
        {
            employees.InsertEmployee(employee);
            await employees.Save();

            var insertedEmployee = employees.GetEmployeeByFirstName(employee.FName);

            return await (insertedEmployee ?? throw new NotFoundException($"Employee with name {employee.FName} not found"));
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await employees.GetEmployeeById(employee.Id) ?? throw new NotFoundException($"Employee with id {employee.Id} not found");

            employeeToUpdate.FName = employee.FName == "" ? employeeToUpdate.FName : employee.FName;

            employees.UpdateEmployee(employeeToUpdate);
            employees.Save();

            return employeeToUpdate;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            if(id <= 0)
            {
                throw new InvalidArgumentException("Id must be greater than 0");
            }

            var employeeToDelete = await employees.GetEmployeeById(id) ?? throw new NotFoundException($"Employee with id {id} not found");

            employees.DeleteEmployee(id);
            await employees.Save();

            return employeeToDelete;
        }
    }
}
