using DBInventorLibrary.Models.Bands;

namespace DBInventorLibrary.Models.ControllerModels
{
    public class InventorControllers
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<ControllerModel> ControllersTeam { get; set; }
        public BandsModel Bands { get; set; }
    }
}
