using ITGuru.FourWheels.Service.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class CustomerDTO : PersonDTO, ICustomer
    {
        public CustomerDTO(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
