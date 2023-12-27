using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Query;
using MediatR;
using Models;

namespace CQRSDemo.Data.Command
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public CreateEmployeeCommand(string name, string address, string email, string phone)
        {
            Name=name;
            Address=address;
            Email=email;
            Phone=phone;

        }
        public string Name{get;set;}
        public string Address{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
        
    }
}