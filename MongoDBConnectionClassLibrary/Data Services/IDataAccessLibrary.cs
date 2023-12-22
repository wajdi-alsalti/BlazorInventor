
namespace MongoDBConnectionClassLibrary.Data_Services
{
    public interface IDataAccessLibrary<T>
    {
        Task AddNew(T document);
        Task DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T updatedDocument);
    }
}