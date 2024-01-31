﻿using employee_crud_.Data;
using employee_crud_.Interfaces.Repositories;
using employee_crud_.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_crud_.Repositories
{
    public class EmployeeRepository(DataContext dataContext) : IEmployeeRepository
    {
        private DbSet<Employee> Employees { get; set; } = dataContext.Employee;

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Employees.Include("Department").ToListAsync();
        }
    }
}
