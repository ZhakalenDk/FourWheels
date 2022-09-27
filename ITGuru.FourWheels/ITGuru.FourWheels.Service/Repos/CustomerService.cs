﻿using ITGuru.FourWheels.Data.Interfaces;

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
            RepoResult result = new RepoResult(string.Empty);
            try
            {
                _context.AddCustomer(entity.MapToInternal());
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
            }

            return result;
        }

        public RepoResult Update(ICustomer entity)
        {
            RepoResult result = new RepoResult(string.Empty);
            try
            {
                _context.UpdateCustomer(entity.MapToInternal());
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
            }

            return result;
        }

        public RepoResult Remove(ICustomer entity)
        {
            RepoResult result = new RepoResult(string.Empty);
            try
            {
                _context.DeleteCustomer(entity.Id);
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
            }

            return result;
        }
    }
}
