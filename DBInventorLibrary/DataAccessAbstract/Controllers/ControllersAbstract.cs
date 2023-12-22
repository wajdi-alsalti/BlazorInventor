using DBInventorLibrary.Models.ControllerModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.Controllers
{
    public class ControllersAbstract : DataAccessLibrary<ControllerModel>, IDataAccessLibrary<ControllerModel>
    {
        public ControllersAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "Controller", nameof(ControllerModel))
        {
        }
    }
}
