using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IEmployeeRepository 
    {
        //Query-2
        public  Task<List<Employee>> GetEmployeeListAsync();
        public Task<Employee> GetEmployeeByIdAsync(int Id);
        //Command-3
        public  Task<Employee> AddEmployeeAsync(Employee employee);
        public  Task<int> UpdateEmployeeAsync(Employee employee);
        public  Task<int> DeleteEmployeeAsync(int Id);

        
        
    }
}