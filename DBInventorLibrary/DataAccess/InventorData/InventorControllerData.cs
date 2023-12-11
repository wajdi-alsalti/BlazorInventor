using DBInventorLibrary.Models.ControllerModels;
using Microsoft.Extensions.Caching.Memory;

namespace DBInventorLibrary.DataAccess.InventorData
{
    public class InventorControllerData : IInventorControllerData
    {
        private readonly IMongoCollection<InventorControllers> _controller;
        private readonly IMemoryCache _cahce;
        private const string CacheName = "InventorControllersData";
        public InventorControllerData(IDbConnection db, IMemoryCache cahce)
        {
            _controller = db.InventorControllerCollection;
            _cahce = cahce;
        }

        #region get controller info from DB

        public async Task<List<InventorControllers>> GetControllerAsync()
        {
            List<InventorControllers> output;
            output = _cahce.Get<List<InventorControllers>>(CacheName);
            if (output == null)
            {
                var result = await _controller.FindAsync(_ => true);
                output = result.ToList();
                // how long the data will be in memory
                _cahce.Set(CacheName, output, TimeSpan.FromSeconds(1));
            }
            return output;
        }

        public async Task<InventorControllers> GetController(string Id)
        {
            var result = await _controller.FindAsync(u => u.Id == Id);
            return result.FirstOrDefault();
        }

        //public async Task<InventorControllers> GetControllerFromAuthentication(string objectId)
        //{
        //    var result = await _controller.FindAsync(u => u.ObjectIdentifer == objectId);
        //    return result.FirstOrDefault();
        //}
        #endregion

        #region Add controller To DB
        public Task CreateController(InventorControllers controller)
        {
            return _controller.InsertOneAsync(controller);
        }
        #endregion

        #region Update controller Info
        //public Task UpadteController(InventorControllers controller)
        //{
        //    var findController = Builders<ControllerModel>.Filter.Eq("Id", controller.Id);

        //    // if find record replace it with new data if there is no record add new one
        //    // replace the user found with the new user
        //    return _controller.ReplaceOneAsync(findController, controller, new ReplaceOptions { IsUpsert = true });
        //}
        #endregion

        #region delete Controller
        //public async Task DeleteController(InventorControllers controller)
        //{
        //    await _controller.DeleteOneAsync(d => d.Id == controller.Id);
        //}
        #endregion
    }
}

