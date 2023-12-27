using CQRSDemo.Data.Command;
using CQRSDemo.Data.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace CQRSDemo.Controllers
{
    [ApiController]
    [Route("api/controller/")]
    public class EmployeesController : Controller
    {
        private IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet("EmployeeList")]
        public async Task<List<Employee>> EmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());//GetEmployeeListQuery is request send to corresponding Handler
            return employeeList;
        }

        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            var employee=await _mediator.Send(new GetEmployeeByIdQuery(){Id=id});
            return employee;
        }
        [HttpPost]
        public async Task<Employee>AddEmployee(Employee employee)
        {
            var employeeReturn=await _mediator.Send(new CreateEmployeeCommand(
                employee.Name,
                employee.Address,
                employee.Email,
                employee.Phone
            ));
            return employeeReturn;
        }

        [HttpPut]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employeeReturn=await _mediator.Send(new UpdateEmployeeCommand(
                employee.Id,
                employee.Name,
                employee.Address,
                employee.Email,
                employee.Phone
            ));
            return employeeReturn;
        }

        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
        }
    }

}