using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;

namespace CQRSDemo.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dbContext;

        

        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // throw new NotImplementedException();
            var result=_dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int Id)
        {
            // throw new NotImplementedException();
            var filteredData= await _dbContext.Employees.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            _dbContext.Employees.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            // throw new NotImplementedException();
            var filteredData= await _dbContext.Employees.Where(x=>x.Id==Id).FirstOrDefaultAsync();
            return filteredData;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            // throw new NotImplementedException();
            var filteredData=await _dbContext.Employees.ToListAsync();
            return filteredData;

        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            // throw new NotImplementedException();
            _dbContext.Employees.Update(employee);
            return await _dbContext.SaveChangesAsync();
        }
    }
}