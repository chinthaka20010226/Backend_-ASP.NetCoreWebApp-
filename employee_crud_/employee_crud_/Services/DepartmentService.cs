using employee_crud_.Interfaces.Repositories;
using employee_crud_.Interfaces.Services;
using employee_crud_.Models.Entities;

namespace employee_crud_.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departments;
        DepartmentService(IDepartmentRepository departments)
        {
            _departments = departments;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            if(id <= 0)
            {
                throw new InvalidAgrumentException("Id must gretaer than 0");
            }

            var department = await _departments.GetDepartmentById(id);

            return department ?? throw new NotFoundException($"Department with id {id} not found");

        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departments.GetDepartments();
        }

        public async Task<Department> InsertDepartment(Department deparment)
        {
            _departments.InsertDepartment(deparment);
            await _departments.Save();

            var insertDepartment = await _departments.GetDepartmentByName(deparment.Name);

            return insertDepartment ?? throw new NotFoundException($"Department with name {deparment.Name} not found");
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var departmentToUpdate = await _departments.GetDepartmentById(department.Id) ?? throw new NotFoundException($"Department with id {department.Id} not found");

            departmentToUpdate.Name = department.Name == "" ? departmentToUpdate.Name : department.Name;

            _departments.UpdateDepartment(departmentToUpdate);
            await _departments.Save();

            return departmentToUpdate;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            if(id <= 0)
            {
                throw new InvalidAgrumentException("Id must be greter than 0");
            }

            var departmentToDelete = await _departments.GetDepartmentById(id) ?? throw new NotFoundException($"Department with id {id} not found");

            _departments.UpdateDepartment(departmentToDelete);
            await _departments.Save();

            return departmentToDelete;
        }
    }
}
