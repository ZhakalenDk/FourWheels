namespace ITGuru.FourWheels.Service
{
    /// <summary>
    /// Serves as a CRUD repository pattern
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to operate on</typeparam>
    /// <typeparam name="TKey">The type the <typeparamref name="TEntity"/> uses as identifier</typeparam>
    /// <typeparam name="TResult">The type of result the repository should return when performing CRUD operations</typeparam>
    public interface ICRUDRepo<TEntity, TKey, TResult>
    {
        IReadOnlyList<TEntity> GetAll();
        TEntity GetById(TKey key);
        TResult Add(TEntity entity);
        TResult Update(TEntity entity);
        TResult Remove(TEntity entity);
    }
}
