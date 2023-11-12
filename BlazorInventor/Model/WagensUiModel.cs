using DBInventorLibrary.Models.Bands;
using System.ComponentModel.DataAnnotations;

namespace BlazorInventor.Model
{
    public class WagensUiModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Add Name !!")]
        public string Name { get; set; }
    }
}
