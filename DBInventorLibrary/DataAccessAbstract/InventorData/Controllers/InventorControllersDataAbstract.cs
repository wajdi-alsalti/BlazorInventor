using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.ControllerModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.InventorData.Controllers
{
    public class InventorControllersDataAbstract : DataBase<InventorControllers>, IDataBase<InventorControllers>
    {
        public InventorControllersDataAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "InventorController", cahce, nameof(InventorControllers))
        {
        }
    }
}
