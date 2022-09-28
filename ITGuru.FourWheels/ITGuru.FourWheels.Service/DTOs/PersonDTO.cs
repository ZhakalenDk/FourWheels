using ITGuru.FourWheels.Service.DTOs.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ITGuru.FourWheels.Service
{
    public abstract class PersonDTO : IPerson
    {
        internal PersonDTO() { /*Restrictive Constructor*/ }
        /// <summary>
        /// Initialize a new instance of type <see cref="PersonDTO"/> with a <paramref name="firstName"/> and <paramref name="lastName"/>.
        /// <br/>
        /// <strong>Note:</strong> This automatically generates a new <see cref="Guid"/> for the initialized entity
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public PersonDTO(string firstName, string lastName)
        {
            Id = new Guid();
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Initialize a new instance of type <see cref="PersonDTO"/> with a <paramref name="firstName"/> and <paramref name="lastName"/>  where the <paramref name="id"/> is specified
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public PersonDTO(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
