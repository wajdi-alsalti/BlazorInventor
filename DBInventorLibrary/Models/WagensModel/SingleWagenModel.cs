using DBInventorLibrary.Models.MaterialsModels;

namespace DBInventorLibrary.Models.WagensModel
{
    public class SingleWagenModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public List<BasicMaterialsModel> WagenMaterials { get; set; } = new();
    }
}
