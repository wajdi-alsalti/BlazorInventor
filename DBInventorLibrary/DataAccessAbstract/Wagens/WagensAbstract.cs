using DBInventorLibrary.Models.WagensModel;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.Wagens
{
    public class WagensAbstract : DataAccessLibrary<SingleWagenModel>, IDataAccessLibrary<SingleWagenModel>
    {
        public WagensAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "SingleWagen", nameof(SingleWagenModel))
        {
        }
    }
}
