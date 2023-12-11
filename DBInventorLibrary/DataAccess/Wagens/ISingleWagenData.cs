using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.DataAccess.Wagens
{
    public interface ISingleWagenData
    {
        Task CreateWagenTest(SingleWagenModel wagen);
        Task DeleteWagen(SingleWagenModel wagen);
        Task<SingleWagenModel> GetWagen(string id);
        Task<List<SingleWagenModel>> GetWagenAsync();
        Task UpadteWagen(SingleWagenModel wagen);
    }
}