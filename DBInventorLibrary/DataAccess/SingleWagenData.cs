using DBInventorLibrary.Models.WagensModel;
using MongoDB.Driver;

namespace DBInventorLibrary.DataAccess
{
    public class SingleWagenData : ISingleWagenData
    {
        private readonly IMongoCollection<SingleWagenModel> _wagens;
        public SingleWagenData(IDbConnection db)
        {
            _wagens = db.SingleWagenCollection;
        }

        #region get wagen info from DB

        public async Task<List<SingleWagenModel>> GetWagenAsync()
        {
            var result = await _wagens.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<SingleWagenModel> GetWagen(string id)
        {
            var result = await _wagens.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        //public async Task<SingleWagenModel> GetWagenFromAuthentication(string objectId)
        //{
        //    var result = await _wagens.FindAsync(u => u.ObjectIdentifer == objectId);
        //    return result.FirstOrDefault();
        //}
        #endregion

        #region Add Wagen To DB
        //public Task CreateWagen(SingleWagenModel wagen)
        //{
        //    return _wagens.InsertOneAsync(wagen);
        //}
        public Task CreateWagenTest(SingleWagenModel wagen)
        {
            return _wagens.InsertOneAsync(wagen);
        }

        #endregion

        #region Update Wagen Info
        public Task UpadteWagen(SingleWagenModel wagen)
        {
            var findwagen = Builders<SingleWagenModel>.Filter.Eq("Id", wagen.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _wagens.ReplaceOneAsync(findwagen, wagen, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
