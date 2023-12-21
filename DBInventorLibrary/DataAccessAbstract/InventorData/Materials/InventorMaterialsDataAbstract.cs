using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.Inventor;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.InventorData.Materials
{
    public class InventorMaterialsDataAbstract : DataBase<InventorModel>, IDataBase<InventorModel>
    {
        public InventorMaterialsDataAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "InventorMaterials", cahce,nameof(InventorModel))
        {
        }
    }
}
