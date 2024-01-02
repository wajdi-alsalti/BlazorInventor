namespace DBInventorLibrary.Models.Bands
{
    public class BasicBandsModel
    {
        public string Id { get; set; }
        public int BandNumer { get; set; }
        public int Position { get; set; }
        public BasicBandsModel()
        {
            
        }
        public BasicBandsModel(BandsModel band)
        {
            Id = band.Id;
            BandNumer = band.Number;
        }
    }
}
