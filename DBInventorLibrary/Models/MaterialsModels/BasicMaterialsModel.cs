namespace DBInventorLibrary.Models.MaterialsModels
{
    public class BasicMaterialsModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int SapNumber { get; set; }

        public BasicMaterialsModel()
        {

        }
        public BasicMaterialsModel(MaterialsModel material)
        {
            Id = material.Id;
            Name = material.Name;
            SapNumber = material.SapNumber;
        }
    }
}
