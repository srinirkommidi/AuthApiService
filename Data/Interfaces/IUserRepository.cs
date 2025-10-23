namespace LogInAuthService.Data.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetData(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task SaveChangesAsync();
        Task DeleteChangesAsync();
        Task<T> GetByIdAsync(
            string id);

    }
}
