using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public class CustomerService : RepositoryBase<Customer>, ICustomerService
    {
        public async Task<RepoResult> AddAsync(ICustomer entity)
        {
            return await base.AddAsync(entity.MapToInternal());
        }

        public async Task<RepoResult> RemoveAsync(ICustomer entity)
        {
            return await base.RemoveAsync(entity.MapToInternal());
        }

        public async Task<RepoResult> UpdateAsync(ICustomer entity)
        {
            return await base.UpdateAsync(entity.MapToInternal());
        }

        async Task<IReadOnlyList<ICustomer>> ICRUDRepo<ICustomer, Guid, RepoResult>.GetAllAsync()
        {
            return await (base.GetAllAsync()).MapToPublic();
        }

        async Task<ICustomer> ICRUDRepo<ICustomer, Guid, RepoResult>.GetByIdAsync(Guid key)
        {
            return (await base.GetByIdAsync(key)).MapToPublic();
        }
    }
}
