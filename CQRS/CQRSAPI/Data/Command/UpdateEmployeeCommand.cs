using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSDemo.Data.Query;
using MediatR;

namespace CQRSDemo.Data.Command
{
    public class UpdateEmployeeCommand :IRequest<int>
    {
        public UpdateEmployeeCommand(int id,string name, string address, string email, string phone)
        {
            Id=id;
            Name=name;
            Address=address;
            Email=email;
            Phone=phone;

        }
        public int Id{get;set;}
        public string Name{get;set;}
        public string Address{get;set;}
        public string Email{get;set;}
        public string Phone{get;set;}
    }
}