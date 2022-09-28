using ITGuru.FourWheels.Data.DataModels;
using Microsoft.Extensions.DependencyInjection;

namespace ITGuru.FourWheels.Service
{
    public static class ICustomerExtensions
    {
        #region Mappers
        private static readonly Mapper<ICustomer, Customer> _internalMapper = new((t, f) =>
        {
            t.Email = f.Email;
            t.FirstName = f.FirstName;
            t.Id = f.Id;
            t.LastName = f.LastName;
            t.Phone = f.Phone;

            return t;
        });

        private static readonly Mapper<Customer, CustomerDTO> _publicMapper = new((t, f) =>
        {
            t.Email = f.Email;
            t.FirstName = f.FirstName;
            t.Id = f.Id;
            t.LastName = f.LastName;
            t.Phone = f.Phone;

            return t;
        });
        #endregion

        internal static Customer MapToInternal(this ICustomer customer)
        {
            return _internalMapper.FromSingle(customer);
        }

        internal static ICustomer MapToPublic(this Customer customer)
        {
            return _publicMapper.FromSingle(customer);
        }

        internal static IEnumerable<ICustomer> MapToPublic(this IEnumerable<Customer> customers)
        {
            return _publicMapper.FromCollection(customers);
        }

        /// <summary>
        /// Retrieves the vehicles associated with <paramref name="customer"/>
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>The retrieved <see cref="IReadOnlyList{T}"/> containing the associated <see cref="IVehicle"/> <see langword="object"/></returns>
        public static IReadOnlyList<IVehicle> GetVehicles(this ICustomer customer)
        {
            var service = ServiceDefinitions.Services.GetService<IVehicleService>();

            var customerVehicles = service.GetAll().Where(v => v.CustomerId == customer.Id)
                .ToList();

            return customerVehicles;
        }
    }
}
