using DBInventorLibrary.Models.Bands;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess.Bands
{
    public class BandsData : IBandsData
    {
        private readonly IMongoCollection<BandsModel> _bands;
        private readonly IMemoryCache _cahce;
        private const string CacheName = "BandsData";
        public BandsData(IDbConnection db, IMemoryCache cahce)
        {
            _bands = db.BandsCollection;
            _cahce = cahce;
        }

        #region get Band info from DB

        public async Task<List<BandsModel>> GetBandAsync()
        {
            List<BandsModel> output;
            output = _cahce.Get<List<BandsModel>>(CacheName);
            if (output == null)
            {
                var result = await _bands.FindAsync(_ => true);
                output = result.ToList();

                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromSeconds(1));
            }
            return output;
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

        #region Update band Info
        public Task UpadteBand(BandsModel band)
        {
            var findBand = Builders<BandsModel>.Filter.Eq("Id", band.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _bands.ReplaceOneAsync(findBand, band, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        #region delete band
        public async Task DeleteBand(BandsModel band)
        {
            await _bands.DeleteOneAsync(d => d.Id == band.Id);
        }
        #endregion
    }
}
