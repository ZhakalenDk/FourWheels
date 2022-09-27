using ITGuru.FourWheels.Service.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class CustomerDTO : PersonDTO, ICustomer
    {
        public CustomerDTO() { }
        public CustomerDTO(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
