using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.ControllerModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.Controllers
{
    public class ControllersAbstract : DataBase<ControllerModel>, IDataBase<ControllerModel>
    {
        public ControllersAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "Controller", cahce,nameof(ControllerModel))
        {
        }
    }
}
