using DBInventorLibrary.Models.ControllerModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.InventorData.Controllers
{
    public class InventorControllersDataAbstract : DataAccessLibrary<InventorControllers>, IDataAccessLibrary<InventorControllers>
    {
        public InventorControllersDataAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "InventorController", nameof(InventorControllers))
        {
        }
    }
}
