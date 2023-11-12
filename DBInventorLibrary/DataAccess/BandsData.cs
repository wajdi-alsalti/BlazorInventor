using DBInventorLibrary.Models.Bands;

namespace DBInventorLibrary.DataAccess
{
    public class BandsData : IBandsData
    {
        private readonly IMongoCollection<BandsModel> _bands;
        public BandsData(IDbConnection db)
        {
            _bands = db.BandsCollection;
        }

        #region get Band info from DB

        public async Task<List<BandsModel>> GetBandAsync()
        {
            var result = await _bands.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<BandsModel> GetBand(string id)
        {
            var result = await _bands.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<BandsModel> GetBandFromAuthentication(string objectId)
        {
            //    var result = await _bands.FindAsync(u => u.ObjectIdentifer == objectId);
            //return result.FirstOrDefault();
            return null;
        }
    #endregion

    #region Add Band To DB
    public Task CreateBand(BandsModel band)
        {
            return _bands.InsertOneAsync(band);
        }
        #endregion

        #region Update user Info
        public Task UpadteBand(BandsModel band)
        {
            var findBand = Builders<BandsModel>.Filter.Eq("Id", band.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _bands.ReplaceOneAsync(findBand, band, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
