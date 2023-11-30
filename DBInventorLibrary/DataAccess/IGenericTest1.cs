using DBInventorLibrary.Models;
using DBInventorLibrary.Models.Bands;

namespace DBInventorLibrary.DataAccess
{
    //public interface IGenericTest1<T> where T : IGenericModel
    public interface IGenericTest1<T> where T : BandsModel
    {
        Task Create(T band);
        Task<bool> Delete(string id);
        Task<T> Get(string id);
        Task<List<T>> GetBandAsync<U>() where U : class, IGenericModel;
        Task<bool> Update(string id, T updatedItem);
    }
}