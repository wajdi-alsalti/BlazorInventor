using DBInventorLibrary.Models.Inventor;

namespace DBInventorLibrary.DataAccess.InventorData.InventorMaterials
{
    public interface IInventorInformation
    {
        Task AddMaterialsAfterInventor(InventorModel materials);
        Task DeleteInventorMaterials(InventorModel materials);
        Task<InventorModel> GetMaterials(string Id);
        Task<List<InventorModel>> GetmaterialsAsync();
        Task UpadteMaterialsAfterInventor(InventorModel materials);
    }
}