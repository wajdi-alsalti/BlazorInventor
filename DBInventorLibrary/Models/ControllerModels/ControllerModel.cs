namespace DBInventorLibrary.Models.ControllerModels
{
    public class ControllerModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifer { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
