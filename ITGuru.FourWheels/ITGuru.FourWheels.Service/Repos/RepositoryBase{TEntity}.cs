using ITGuru.FourWheels.Service.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    public abstract class RepositoryBase<TEntity> : ICRUDRepo<TEntity, Guid, RepoResult>
    {
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            //  TODO: [GetAll] Integrate mock data access

            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(Guid key)
        {
            //  TODO: [GetByID] Integrate mock data access

            throw new NotImplementedException();
        }

        public virtual async Task<RepoResult> AddAsync(TEntity entity)
        {
            //  TODO: [Add] Integrate mock data access

            throw new NotImplementedException();
        }

        public virtual async Task<RepoResult> UpdateAsync(TEntity entity)
        {
            //  TODO: [Update] Integrate mock data access

            throw new NotImplementedException();
        }

        public virtual async Task<RepoResult> RemoveAsync(TEntity entity)
        {
            //  TODO: [Remove] Integrate mock data access

            throw new NotImplementedException();
        }
    }
}
