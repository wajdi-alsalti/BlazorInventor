using DBInventorLibrary.Models.Bands;
using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.DataAccess
{
    public interface IDbConnection
    {
        IMongoCollection<BandsModel> BandsCollection { get; }
        string BandsCollectionName { get; set; }
        MongoClient Client { get; }
        IMongoCollection<ControllerModel> ControllerCollection { get; }
        string ControllerCollectionName { get; set; }
        string DbName { get; }
        string MaterialCollectionName { get; set; }
        IMongoCollection<MaterialsModel> MaterialsCollection { get; }
        IMongoCollection<WagensModel> WagensCollection { get; }
        IMongoCollection<SingleWagenModel> SingleWagenCollection { get; }
        string WagensCollectionName { get; set; }
        IMongoCollection<InventorControllers> InventorControllerCollection { get; }
    }
}