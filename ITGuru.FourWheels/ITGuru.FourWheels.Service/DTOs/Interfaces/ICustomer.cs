using ITGuru.FourWheels.Service.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public interface ICustomer : IPerson
    {
        string Phone { get; }
        string Email { get; }
    }
}
