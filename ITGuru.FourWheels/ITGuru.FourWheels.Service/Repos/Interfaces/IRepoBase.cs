using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITGuru.FourWheels.Service.Repos
{
    /// <summary>
    /// Defines an queryable base for repository patterns
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that can be queried</typeparam>
    public interface IRepoBase<TEntity>
    {
        IQueryable<TEntity> GetQueryable();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity>> _condition);
    }
}
