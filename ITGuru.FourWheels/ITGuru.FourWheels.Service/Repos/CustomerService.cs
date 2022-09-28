using ITGuru.FourWheels.DataLayer;

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
                _context.SoftDeleteCustomer(entity.Id);
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
