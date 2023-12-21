using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.Models.MaterialsModels;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccessAbstract.Materilas
{
    public class MaterialsAbstract : DataBase<MaterialsModel>, IDataBase<MaterialsModel>
    {
        public MaterialsAbstract(IConfiguration config, IMemoryCache cahce) : base(config, "Materials", cahce,nameof(MaterialsModel))
        {
        }
    }
}
