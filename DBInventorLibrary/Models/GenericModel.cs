namespace DBInventorLibrary.Models
{
    public interface IGenericModel
    {
        public string Id { get; set; }
        public string ObjectIdentifer { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int SapNumber { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
