using LogInAuthService.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LogInAuthService.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UserDBContext _context;
        public readonly DbSet<T> _dbSet;
        public GenericRepository(UserDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> predicate)
        {
            // Use Where and FirstOrDefault on the DbSet
            return _dbSet.FirstOrDefault(predicate)!;
        }

        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            // Use Where and FirstOrDefaultAsync on the DbSet
            return await _dbSet.FirstOrDefaultAsync(predicate)!;
        }
    }
}
