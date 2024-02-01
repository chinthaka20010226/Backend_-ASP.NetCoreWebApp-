using employee_crud_.Data;
using employee_crud_.Interfaces.Repositories;
using employee_crud_.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_crud_.Repositories
{
    public class DepartmentRepository(DataContext dataContext) : IDepartmentRepository
    {
        private DbSet<Department> _departments { get; set; } = dataContext.Department;

        /*
        private readonly DataContext _dataContext;
        private DbSet<Department> _departments;

        public DepartmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _departments = _dataContext.Department;
        }

        private DbSet<Department> Department
        {
            get { return _departments; }
            set { _departments = value; }
        }
        */

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _departments.FindAsync(id);
        }

        public async Task<Department?> GetDepartmentByName(String Name)
        {
            return await _departments.FirstOrDefaultAsync(department => department.Name == Name);
        }

        public async Task<IEnumerable<Department?>> GetDepartments()
        {
            return await _departments.ToListAsync();
        }

        public void InsertDepartment(Department department)
        {
            _departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            _departments.Update(department);
        }

        public async void DeleteDepartment(int id)
        {
            var department = await _departments.FindAsync(id);

            if(department != null)
            {
                _departments.Remove(department);
            }
        }

        public async Task Save()
        {
            await dataContext.SaveChangesAsync();
        }
    }
}
