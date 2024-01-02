using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.Models.Inventor
{
    public class InventorModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public InventorControllers Controllers { get; set; }
        public BasicWagenModel WagenHasBeenControllerd { get; set; }
        public List<MaterialsModel> MaterialsHasBeenControllerd { get; set; }
        public bool HasBeenControllerd { get; set; }
    }
}
