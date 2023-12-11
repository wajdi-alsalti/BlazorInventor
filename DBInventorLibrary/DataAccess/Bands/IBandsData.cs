using DBInventorLibrary.Models.Bands;

namespace DBInventorLibrary.DataAccess.Bands
{
    public interface IBandsData
    {
        Task CreateBand(BandsModel band);
        Task DeleteBand(BandsModel band);
        Task<BandsModel> GetBand(string id);
        Task<List<BandsModel>> GetBandAsync();
        Task<BandsModel> GetBandFromAuthentication(string objectId);
        Task UpadteBand(BandsModel band);
    }
}