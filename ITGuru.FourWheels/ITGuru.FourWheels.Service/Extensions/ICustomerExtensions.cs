using ITGuru.FourWheels.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Customer MapToInternal(this ICustomer customer)
        {
            return _internalMapper.FromSingle(customer);
        }

        public static ICustomer MapToPublic(this Customer customer)
        {
            return _publicMapper.FromSingle(customer);
        }

        public static IEnumerable<ICustomer> MapToPublic(this IEnumerable<Customer> customers)
        {
            return _publicMapper.FromCollection(customers);
        }

        public static IReadOnlyList<IVehicle> GetVehicles(this ICustomer customer)
        {
            //  TODO: Implement vehicle retrieval

            return new List<IVehicle>();
        }
    }
}
