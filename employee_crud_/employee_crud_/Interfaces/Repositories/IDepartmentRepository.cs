using employee_crud_.Models.Entities;

namespace employee_crud_.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetDepartmentById(int id);
        Task<Department?> GetDepartmentByName(String name);
        Task<IEnumerable<Department?>> GetDepartments();
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);

        Task Save();
    }
}
