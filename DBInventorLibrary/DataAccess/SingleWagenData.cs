using DBInventorLibrary.Models.WagensModel;
using MongoDB.Driver;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using DBInventorLibrary.Models.MaterialsModels;

namespace DBInventorLibrary.DataAccess
{
    public class SingleWagenData : ISingleWagenData
    {
        private readonly IMongoCollection<SingleWagenModel> _wagens;
        private readonly IMemoryCache _cahce;

        private const string CacheName = "WagensData";


        public SingleWagenData(IDbConnection db,IMemoryCache cahce)
        {
            _wagens = db.SingleWagenCollection;
            _cahce = cahce;
        }

        #region get wagen info from DB

        public async Task<List<SingleWagenModel>> GetWagenAsync()
        {
            List<SingleWagenModel> output;
            output = _cahce.Get<List<SingleWagenModel>>(CacheName);
            if (output == null)
            {
                var result = await _wagens.FindAsync(_ => true);
                output = result.ToList();

                // how long the data will be in memory
                _cahce.Set(CacheName,output,TimeSpan.FromSeconds(1));
            }
            return output;
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

        #region delete Wagen
        public async Task DeleteWagen(SingleWagenModel wagen)
        {
            await _wagens.DeleteOneAsync(d => d.Id == wagen.Id);
        }
        #endregion
    }
}
