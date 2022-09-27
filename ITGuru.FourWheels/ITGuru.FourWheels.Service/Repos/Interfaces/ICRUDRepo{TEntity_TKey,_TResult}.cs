using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service
{
    /// <summary>
    /// Serves as an <see langword="async"/> CRUD repository pattern
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to operate on</typeparam>
    /// <typeparam name="TKey">The type the <typeparamref name="TEntity"/> uses as identifier</typeparam>
    /// <typeparam name="TResult">The type of result the repository should return when performing CRUD operations</typeparam>
    public interface ICRUDRepo<TEntity, TKey, TResult>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey key);
        Task<TResult> AddAsync(TEntity entity);
        Task<TResult> UpdateAsync(TEntity entity);
        Task<TResult> RemoveAsync(TEntity entity);
    }
}
