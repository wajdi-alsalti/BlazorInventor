using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.Bands;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.Bands
{
    public class BandsAbstract : DataBase<BandsModel>, IDataBase<BandsModel>
    {
        public BandsAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "Bands", cahce,nameof(BandsModel))
        {
        }
    }
}
