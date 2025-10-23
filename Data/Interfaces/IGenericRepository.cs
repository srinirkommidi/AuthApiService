using System.Linq.Expressions;

namespace LogInAuthService.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetSingleByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(object id);

    }
}

