namespace Microservices.Catalog.Core.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync<TKey>(TKey id);
        Task<T> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete<TKey>(TKey id);
    }
}
