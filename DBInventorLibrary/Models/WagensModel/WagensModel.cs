namespace DBInventorLibrary.Models.WagensModel
{
    public class WagensModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ObjectIdentifer { get; set; }
        public string Number { get; set; }
    }
}
