using employee_crud_.Models.Entities;

namespace employee_crud_.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetEmployeeById(int id);
        Task<Employee?> GetEmployeeFirstName(String firstName);
        Task<IEnumerable<Employee?>> GetEmployees();
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
        Task Save();
    }
}
