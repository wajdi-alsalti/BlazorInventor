using DBInventorLibrary.Models.ControllerModels;

namespace DBInventorLibrary.DataAccess.Controllers
{
    public interface IControllerData
    {
        Task CreateController(ControllerModel controller);
        Task DeleteController(ControllerModel controller);
        Task<ControllerModel> GetController(string id);
        Task<List<ControllerModel>> GetControllerAsync();
        Task<ControllerModel> GetControllerFromAuthentication(string objectId);
        Task UpadteController(ControllerModel controller);
    }
}