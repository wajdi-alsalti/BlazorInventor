namespace DBInventorLibrary.Models.WagensModel
{
    public class BasicWagenModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public BasicWagenModel()
        {

        }
        public BasicWagenModel(SingleWagenModel wagen)
        {
            Name = wagen.Name;
            Id = wagen.Id;
            Position = wagen.Position;

        }
    }
}
