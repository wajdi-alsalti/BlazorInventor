using DBInventorLibrary.Models.MaterialsModels;

namespace DBInventorLibrary.DataAccess
{
    public class MaterialsData : IMaterialsData
    {
        private readonly IMongoCollection<MaterialsModel> _materials;
        public MaterialsData(IDbConnection db)
        {
            _materials = db.MaterialsCollection;
        }

        #region get wagen info from DB

        public async Task<List<MaterialsModel>> GetMaterialAsync()
        {
            var result = await _materials.FindAsync(_ => true);
            return result.ToList();
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

        #region Add Wagen To DB
        public Task CreateMaterial(MaterialsModel material)
        {
            return _materials.InsertOneAsync(material);
        }
        #endregion

        #region Update Wagen Info
        public Task UpadteMaterial(MaterialsModel material)
        {
            var findMaterial = Builders<MaterialsModel>.Filter.Eq("Id", material.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _materials.ReplaceOneAsync(findMaterial, material, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}
