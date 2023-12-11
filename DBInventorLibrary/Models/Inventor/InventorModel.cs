using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.MaterialsModels;

namespace DBInventorLibrary.Models.Inventor
{
    public class InventorModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public InventorControllers Controllers { get; set; }
        public int BandNumber { get; set; }
        public int WagenPosition { get; set; }
        public string WagenName { get; set; }
        public List<MaterialsModel> MaterialsControllerd { get; set; }
        public bool HasBeenControllerd { get; set; }
    }
}
