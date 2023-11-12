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
        public int SapNumber { get; set; }
        
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
