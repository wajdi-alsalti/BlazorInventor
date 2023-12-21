using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.WagensModel;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.Wagens
{
    public class WagensAbstract : DataBase<SingleWagenModel>, IDataBase<SingleWagenModel>
    {
        public WagensAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "SingleWagen", cahce,nameof(SingleWagenModel))
        {
        }
    }
}
