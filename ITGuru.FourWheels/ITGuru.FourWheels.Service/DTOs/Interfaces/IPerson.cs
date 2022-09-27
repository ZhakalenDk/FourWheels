using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service.DTOs.Interfaces
{
    public interface IPerson
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
