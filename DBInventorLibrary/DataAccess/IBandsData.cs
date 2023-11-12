using DBInventorLibrary.Models.Bands;

namespace DBInventorLibrary.DataAccess
{
    public interface IBandsData
    {
        Task CreateBand(BandsModel band);
        Task<BandsModel> GetBand(string id);
        Task<List<BandsModel>> GetBandAsync();
        Task<BandsModel> GetBandFromAuthentication(string objectId);
        Task UpadteBand(BandsModel band);
    }
}