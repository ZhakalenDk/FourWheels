using System.ComponentModel.DataAnnotations;

namespace ITGuru.FourWheels.Service
{
    public class CustomerDTO : PersonDTO, ICustomer
    {
        public CustomerDTO() { /*Empty*/ }
        public CustomerDTO(Guid id, string firstName, string lastName) : base(id, firstName, lastName) { /*Empty*/ }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
