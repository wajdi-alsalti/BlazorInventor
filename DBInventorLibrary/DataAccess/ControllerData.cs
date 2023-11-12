using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.MaterialsModels;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess
{
    public class ControllerData : IControllerData
    {
        private readonly IMongoCollection<ControllerModel> _controller;
        private readonly IMemoryCache _cahce;
        private const string CacheName = "ControllersData";
        public ControllerData(IDbConnection db, IMemoryCache cahce)
        {
            _controller = db.ControllerCollection;
            _cahce = cahce;
        }

        #region get controller info from DB

        public async Task<List<ControllerModel>> GetControllerAsync()
        {
            List<ControllerModel> output;
            output = _cahce.Get<List<ControllerModel>>(CacheName);
            if (output == null)
            {
                var result = await _controller.FindAsync(_ => true);
                output = result.ToList();
                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }
            return output;
        }

        public async Task<ControllerModel> GetController(string id)
        {
            var result = await _controller.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<ControllerModel> GetControllerFromAuthentication(string objectId)
        {
            var result = await _controller.FindAsync(u => u.ObjectIdentifer == objectId);
            return result.FirstOrDefault();
        }
        #endregion

        #region Add controller To DB
        public Task CreateController(ControllerModel controller)
        {
            return _controller.InsertOneAsync(controller);
        }
        #endregion

        #region Update controller Info
        public Task UpadteController(ControllerModel controller)
        {
            var findController = Builders<ControllerModel>.Filter.Eq("Id", controller.Id);

            // if find record replace it with new data if there is no record add new one
            // replace the user found with the new user
            return _controller.ReplaceOneAsync(findController, controller, new ReplaceOptions { IsUpsert = true });
        }
        #endregion
    }
}

