namespace DBInventorLibrary.DataAccessAbstract.Services
{
    public interface IDataBase<T>
    {
        Task DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task AddNew(T document);
        Task UpdateAsync(string id, T updatedDocument);
    }
}