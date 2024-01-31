using employee_crud_.Data;
using employee_crud_.Interfaces.Repositories;

namespace employee_crud_.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        EmployeeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
