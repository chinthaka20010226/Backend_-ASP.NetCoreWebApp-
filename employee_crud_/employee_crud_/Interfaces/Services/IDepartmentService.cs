using employee_crud_.Models.Entities;

namespace employee_crud_.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentId(int id);
        Task<IEnumerable<Department>> GetDepartment();
        Task<Department> InsertDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
    }
}
