using ITGuru.FourWheels.Data;

namespace ITGuru.FourWheels.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(IDataLayer context)
        {
            _context = context;
        }

        private readonly IDataLayer _context;

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
            RepoResult result = new RepoResult("Customer Added");
            try
            {
                if (!_context.AddCustomer(entity.MapToInternal()))
                {
                    result.Message = "Customer couldn't be added";
                }
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
            RepoResult result = new RepoResult("Customer Updated");
            try
            {
                if (!_context.UpdateCustomer(entity.MapToInternal()))
                {
                    result.Message = "Customer couldn't be updated";
                }
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
            RepoResult result = new RepoResult("Customer Removed");
            try
            {
                if (!_context.SoftDeleteCustomer(entity.Id))
                {
                    result.Message = "Customer couldn't be removed";
                }
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
