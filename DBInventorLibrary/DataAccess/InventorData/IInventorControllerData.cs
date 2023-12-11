using DBInventorLibrary.Models.ControllerModels;

namespace DBInventorLibrary.DataAccess.InventorData
{
    public interface IInventorControllerData
    {
        Task CreateController(InventorControllers controller);
        Task<InventorControllers> GetController(string bandId);
        Task<List<InventorControllers>> GetControllerAsync();
    }
}