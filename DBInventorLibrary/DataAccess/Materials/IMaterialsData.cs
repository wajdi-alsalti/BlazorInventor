using DBInventorLibrary.Models.MaterialsModels;

namespace DBInventorLibrary.DataAccess.Materials
{
    public interface IMaterialsData
    {
        Task CreateMaterial(MaterialsModel material);
        Task DeleteMaterila(MaterialsModel material);
        Task<MaterialsModel> GetMaterial(string id);
        Task<List<MaterialsModel>> GetMaterialAsync();
        Task<MaterialsModel> GetMaterialFromAuthentication(string objectId);
        Task UpadteMaterial(MaterialsModel material);
    }
}