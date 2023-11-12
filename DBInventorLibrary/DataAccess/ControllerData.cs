using DBInventorLibrary.Models.ControllerModels;

namespace DBInventorLibrary.DataAccess
{
    public class ControllerData : IControllerData
    {
        private readonly IMongoCollection<ControllerModel> _controller;
        public ControllerData(IDbConnection db)
        {
            _controller = db.ControllerCollection;
        }

        #region get controller info from DB

        public async Task<List<ControllerModel>> GetControllerAsync()
        {
            var result = await _controller.FindAsync(_ => true);
            return result.ToList();
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

