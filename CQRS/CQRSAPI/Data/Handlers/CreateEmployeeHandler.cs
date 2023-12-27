using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Command;
using Models;
using Services;
using MediatR;

namespace CQRSDemo.Data.Handlers
//IRequestHandler separates request Handler(CreateEmployeeHandler) from request(CreateEmployeeCommand)
{
    public class CreateEmployeeHandler: IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        //responsible for handling the CreateEmployeeCommand requests 
        // by processing the request data and performing operations to create an employee.
        public async Task <Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee emp=new Employee
            {
                Name=request.Name,
                Email=request.Email,
                Address=request.Address,
                Phone=request.Phone
            };
            return await _employeeRepository.AddEmployeeAsync(emp);
        }
        
    }
}