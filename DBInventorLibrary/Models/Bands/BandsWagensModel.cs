using DBInventorLibrary.Models.WagensModel;

namespace DBInventorLibrary.Models.Bands
{
    public class BandsWagensModel
    {
        public string Id { get; set; }
        public int Number { get; set; }

        // List of wagens the band have
        public List<BasicWagenModel> WagensList { get; set; } = new List<BasicWagenModel>();
    }
}
