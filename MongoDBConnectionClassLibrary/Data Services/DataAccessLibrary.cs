using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBConnectionClassLibrary.Data_Services
{
    public abstract class DataAccessLibrary<T> : IDataAccessLibrary<T>
    {
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoDatabase _db;

        private readonly IConfiguration _config;

        private string _connectionString = "";
        private string _database = "";
        private string DbName { get; set; }

        private MongoClient Client { get; set; }

        private readonly IMemoryCache _cahce;
        private readonly string CacheName = "";

        public DataAccessLibrary(IConfiguration config, IMemoryCache cahce, string database ,string connectionString, string collectionName, string cacheNames)
        {
            // read from appsetting file the config and return the connection string and data base name
            _config = config;
            _database = database;
            DbName = _config[_database]!;

            // new client for mongo and connect to DB
            _connectionString = connectionString;
            Client = new MongoClient(_config.GetConnectionString(_connectionString));
            _db = Client.GetDatabase(DbName);

            _collection = _db.GetCollection<T>(collectionName);

            CacheName = cacheNames;

            _cahce = cahce;
        }

        public Task AddNew(T document)
        {
            return _collection.InsertOneAsync(document);
        }

        public Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = _collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }

        public async Task UpdateAsync(string id, T updatedDocument)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            await _collection.ReplaceOneAsync(filter, updatedDocument, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> output;
            output = _cahce.Get<List<T>>(CacheName)!;
            if (output == null)
            {
                var result = await _collection.FindAsync(_ => true);
                output = result.ToList();

                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromSeconds(1));
            }
            return output;
        }
    }
}
