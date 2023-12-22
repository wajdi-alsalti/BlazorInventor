using DBInventorLibrary.Models.Inventor;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.InventorData.Materials
{
    public class InventorMaterialsDataAbstract : DataAccessLibrary<InventorModel>, IDataAccessLibrary<InventorModel>
    {
        public InventorMaterialsDataAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "InventorMaterials", nameof(InventorModel))
        {
        }
    }
}
