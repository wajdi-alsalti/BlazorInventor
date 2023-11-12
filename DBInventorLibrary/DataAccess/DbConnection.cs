using DBInventorLibrary.Models.Bands;
using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;
using Microsoft.Extensions.Configuration;

namespace DBInventorLibrary.DataAccess
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private string _connectionId = "MongoDB";
        public string DbName { get; private set; }

        // Collection of data or like a table of data
        public string BandsCollectionName { get; set; } = "Bands";
        public string MaterialCollectionName { get; set; } = "Materials";
        public string WagensCollectionName { get; set; } = "Wagens";
        public string SingleWagenCollectionName { get; set; } = "SingleWagen";
        public string ControllerCollectionName { get; set; } = "Controller";
        public MongoClient Client { get; private set; }

        public IMongoCollection<BandsModel> BandsCollection { get; private set; }
        public IMongoCollection<MaterialsModel> MaterialsCollection { get; private set; }
        public IMongoCollection<WagensModel> WagensCollection { get; private set; }
        public IMongoCollection<SingleWagenModel> SingleWagenCollection { get; private set; }
        public IMongoCollection<ControllerModel> ControllerCollection { get; private set; }

        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);
            BandsCollection = _db.GetCollection<BandsModel>(BandsCollectionName);
            MaterialsCollection = _db.GetCollection<MaterialsModel>(MaterialCollectionName);
            WagensCollection = _db.GetCollection<WagensModel>(WagensCollectionName);
            SingleWagenCollection = _db.GetCollection<SingleWagenModel>(SingleWagenCollectionName);
            ControllerCollection = _db.GetCollection<ControllerModel>(ControllerCollectionName);

        }
    }
}
