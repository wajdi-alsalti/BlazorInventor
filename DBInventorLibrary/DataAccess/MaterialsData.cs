using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess
{
    public class MaterialsData : IMaterialsData
    {
        private readonly IMongoCollection<MaterialsModel> _materials;
        private readonly IMemoryCache _cahce;
        private const string CacheName = "MaterialsData";
        public MaterialsData(IDbConnection db, IMemoryCache cahce)
        {
            _materials = db.MaterialsCollection;
            _cahce = cahce;
        }

        #region get Materila info from DB

        public async Task<List<MaterialsModel>> GetMaterialAsync()
        {
            List<MaterialsModel> output;
            output = _cahce.Get<List<MaterialsModel>>(CacheName);
            if (output == null)
            {
                var result = await _materials.FindAsync(_ => true);
                output = result.ToList();

                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromSeconds(1));
            }
            return output;
        }

        public async Task<MaterialsModel> GetMaterial(string id)
        {
            var result = await _materials.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<MaterialsModel> GetMaterialFromAuthentication(string objectId)
        {
            //var result = await _materials.FindAsync(u => u.ObjectIdentifer == objectId);
            //return result.FirstOrDefault();
            return null;
        }
        #endregion

        #region Add Materila To DB
        public Task CreateMaterial(MaterialsModel material)
        {
            return _materials.InsertOneAsync(material);
        }
        #endregion

        #region Update Materila Info
        public Task UpadteMaterial(MaterialsModel material)
        {
            var findMaterial = Builders<MaterialsModel>.Filter.Eq("Id", material.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _materials.ReplaceOneAsync(findMaterial, material, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        #region delete materila
        public async Task DeleteMaterila(MaterialsModel material)
        {
            await _materials.DeleteOneAsync(d => d.Id == material.Id);
        }
        #endregion
    }
}
