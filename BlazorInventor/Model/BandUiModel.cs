using DBInventorLibrary.Models.WagensModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorInventor.Model
{
    public class BandUiModel
    {
        public string Id { get; set; }
        [Required]
        [Range(500, 550)]
        public int Number { get; set; }
        public int Position { get; set; }
        [Required]
        public List<BasicWagenModel> Wagens { get; set; } = new List<BasicWagenModel>();
    }
}
