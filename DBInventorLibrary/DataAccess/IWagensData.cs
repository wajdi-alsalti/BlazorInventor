using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.DataAccess
{
    public interface IWagensData
    {
        Task CreateWagen(WagensModel band);
        Task<WagensModel> GetWagen(string id);
        Task<List<WagensModel>> GetWagenAsync();
        Task<WagensModel> GetWagenFromAuthentication(string objectId);
        Task UpadteWagen(WagensModel band);
    }
}