using ITGuru.FourWheels.Data.DataModels;
using ITGuru.FourWheels.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(IData context)
        {
            _context = context;
        }

        private readonly IData _context;

        public IReadOnlyList<ICustomer> GetAll()
        {
            return _context.GetAllCustomers().MapToPublic()
                .ToList();
        }

        public ICustomer GetById(Guid key)
        {
            return GetAll().FirstOrDefault(c => c.Id == key);
        }

        public RepoResult Add(ICustomer entity)
        {
            _context.AddCustomer(entity.MapToInternal());

            return new RepoResult("???");
        }

        public RepoResult Update(ICustomer entity)
        {
            _context.UpdateCustomer(entity.MapToInternal());

            return new RepoResult("???");
        }

        public RepoResult Remove(ICustomer entity)
        {
            _context.DeleteCustomer(entity.Id);

            return new RepoResult("???");
        }
    }
}
