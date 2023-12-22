using DBInventorLibrary.Models.MaterialsModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDBConnectionClassLibrary.Data_Services;

namespace DBInventorLibrary.DataAccessAbstract.Materilas
{
    public class MaterialsAbstract : DataAccessLibrary<MaterialsModel>, IDataAccessLibrary<MaterialsModel>
    {
        public MaterialsAbstract(IConfiguration config, IMemoryCache cahce) : base(config, cahce, "DatabaseName", "MongoDB", "Materials", nameof(MaterialsModel))
        {
        }
    }
}
