using DBInventorLibrary.Models;
using DBInventorLibrary.Models.Bands;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess
{
    public class GenericTest<T> : IGenericTest1<T> where T : BandsModel
    {
        private readonly IMongoCollection<T> _dbCollection;
        private readonly IMemoryCache _cahce;

        public GenericTest(IDbConnection db, IMemoryCache cahce, IMongoDatabase database)
        {

            // collection name
            _dbCollection = database.GetCollection<T>(nameof(db.BandsCollectionName));
            _cahce = cahce;
        }

        #region get Band info from DB

        public async Task<List<T>> GetBandAsync<U>() where U : class, IGenericModel
        {
            List<T> output;
            output = _cahce.Get<List<T>>(nameof(T));
            if (output == null)
            {
                var result = await _dbCollection.FindAsync(_ => true);
                output = result.ToList();

                // how long the data will be in memory
                _cahce.Set(nameof(T), output, TimeSpan.FromSeconds(1));
            }
            return output;
        }

        //public async Task<T> GetBand<U>(string id) where U : class , IGenericModel
        //{
        //    var result = await _dbCollection.FindAsync(u => u.Id == id);
        //    return result.FirstOrDefault();

        //}
        public async Task<T> Get(string id)
        {
            var result = await _dbCollection.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        #endregion

        #region Add Band To DB
        public Task Create(T band)
        {
            return _dbCollection.InsertOneAsync(band);
        }
        #endregion

        #region Update band Info
        //public Task UpadteBand<U>(U band) where U : class ,IGenericModel
        //{
        //    //var findBand = Builders<GenericModel<T>>.Filter.Eq("Id", band.Id);
        //    var findBand = Builders<T>.Filter.Eq("Id", band.Id);

        //    // if find record replace it with new data if there is no record add new one
        //    // replace the user found with the new user
        //    return _dbCollection.ReplaceOneAsync(findBand, band, new ReplaceOptions { IsUpsert = true });
        //}

        public async Task<bool> Update(string id, T updatedItem)
        {
            var result = await _dbCollection.ReplaceOneAsync(u => u.Id == id, updatedItem);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region delete band
        //public async Task DeleteBand(T band)
        //{
        //    await _dbCollection.DeleteOneAsync(d => d.Id == band.Id);
        //}

        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _dbCollection.DeleteOneAsync(u => u.Id == id);
            return deleteResult.DeletedCount > 0;
        }
        #endregion
    }
}
