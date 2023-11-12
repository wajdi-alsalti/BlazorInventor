using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.Models.Bands
{
    public class BandsModel
    {
        [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Number { get; set; }
        public List<BasicWagenModel> Wagens { get; set; } = new List<BasicWagenModel>();
    }
}
