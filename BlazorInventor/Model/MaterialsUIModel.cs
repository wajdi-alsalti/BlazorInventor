using System.ComponentModel.DataAnnotations;

namespace BlazorInventor.Model
{
    public class MaterialsUIModel
    {
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1000, int.MaxValue)]
        public int SapNumber { get; set; } = 1000;
        
        
        [Required]
        [Range(1, 5000)]
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
