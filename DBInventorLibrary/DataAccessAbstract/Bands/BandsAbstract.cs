using DBInventorLibrary.Models.Bands;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.Bands
{
    public class BandsAbstract : DataAccessLibrary<BandsModel>, IDataAccessLibrary<BandsModel>
    {
        public BandsAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "Bands", nameof(BandsModel))
        {
        }
    }
}
