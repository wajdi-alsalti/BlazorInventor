using DBInventorLibrary.Models.Inventor;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess.InventorData.InventorMaterials
{
    public class InventorInformation : IInventorInformation
    {
        private readonly IMongoCollection<InventorModel> _materials;
        private readonly IMemoryCache _cahce;
        private const string CacheName = "InventorMaterials";
        public InventorInformation(IDbConnection db, IMemoryCache cahce)
        {
            _materials = db.InventorMaterialsCollection;
            _cahce = cahce;
        }

        #region get materials info from DB

        public async Task<List<InventorModel>> GetmaterialsAsync()
        {
            List<InventorModel> output;
            output = _cahce.Get<List<InventorModel>>(CacheName);
            if (output == null)
            {
                var result = await _materials.FindAsync(_ => true);
                output = result.ToList();
                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromSeconds(1));
            }
            return output;
        }

        public async Task<InventorModel> GetMaterials(string Id)
        {
            var result = await _materials.FindAsync(u => u.Id == Id);
            return result.FirstOrDefault();
        }


        #endregion

        #region Add materials To DB
        public Task AddMaterialsAfterInventor(InventorModel materials)
        {
            return _materials.InsertOneAsync(materials);
        }
        #endregion

        #region Update materials Info
        public Task UpadteMaterialsAfterInventor(InventorModel materials)
        {
            var findController = Builders<InventorModel>.Filter.Eq("Id", materials.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _materials.ReplaceOneAsync(findController, materials, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        #region delete Controller
        public async Task DeleteInventorMaterials(InventorModel materials)
        {
            await _materials.DeleteOneAsync(d => d.Id == materials.Id);
        }
        #endregion
    }
}

