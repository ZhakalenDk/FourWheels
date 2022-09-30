using ITGuru.FourWheels.Data;

namespace ITGuru.FourWheels.Service
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {
            _data = DataLayer.Data;
        }
        private IDataLayer _data;

        public IReadOnlyList<ICustomer> GetAll()
        {
            return _data.GetAllCustomers().MapToPublic()
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
                if (!_data.AddCustomer(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Customer couldn't be added";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public RepoResult Update(ICustomer entity)
        {
            RepoResult result = new RepoResult("Customer Updated");
            try
            {
                if (!_data.UpdateCustomer(entity.MapToInternal()))
                {
                    result.Succeeded = false;
                    result.Message = "Customer couldn't be updated";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public RepoResult Remove(ICustomer entity)
        {
            RepoResult result = new RepoResult("Customer Removed");
            try
            {
                if (!_data.SoftDeleteCustomer(entity.Id))
                {
                    result.Succeeded = false;
                    result.Message = "Customer couldn't be removed";
                }
            }
            catch (Exception e)
            {
                result.Exception = e;
                result.Message = e.Message;
                result.Succeeded = false;
            }

            return result;
        }
    }
}
