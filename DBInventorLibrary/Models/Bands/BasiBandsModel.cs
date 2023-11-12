namespace DBInventorLibrary.Models.Bands
{
    public class BasiBandsModel
    {
        public string Id { get; set; }
        public int BandNumer { get; set; }
        public int Position { get; set; }
        public BasiBandsModel()
        {
            
        }
        public BasiBandsModel(BandsModel band)
        {
            Id = band.Id;
            BandNumer = band.Number;
            //Position = band.Position ;
        }
    }
}
