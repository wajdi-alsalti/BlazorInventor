using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.DataAccess
{
    public class WagensData : IWagensData
    {
        private readonly IMongoCollection<WagensModel> _wagens;
        public WagensData(IDbConnection db)
        {
            _wagens = db.WagensCollection;
        }

        #region get wagen info from DB

        public async Task<List<WagensModel>> GetWagenAsync()
        {
            var result = await _wagens.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<WagensModel> GetWagen(string id)
        {
            var result = await _wagens.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<WagensModel> GetWagenFromAuthentication(string objectId)
        {
            var result = await _wagens.FindAsync(u => u.ObjectIdentifer == objectId);
            return result.FirstOrDefault();
        }
        #endregion

        #region Add Wagen To DB
        public Task CreateWagen(WagensModel wagen)
        {
            return _wagens.InsertOneAsync(wagen);
        }
        public Task CreateWagenTest(WagensModel wagen)
        {
            return _wagens.InsertOneAsync(wagen);
        }

        #endregion

        #region Update Wagen Info
        public Task UpadteWagen(WagensModel wagen)
        {
            var findwagen = Builders<WagensModel>.Filter.Eq("Id", wagen.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _wagens.ReplaceOneAsync(findwagen, wagen, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
