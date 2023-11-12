namespace DBInventorLibrary.Models.MaterialsModels
{
    public class MaterialsModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //public string ObjectIdentifer { get; set; }
        public string Name { get; set; }
        public int SapNumber { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
