using ITGuru.FourWheels.Service.DTOs.Interfaces;

namespace ITGuru.FourWheels.Service
{
    public interface ICustomer : IPerson
    {
        string Phone { get; }
        string Email { get; }
    }
}
