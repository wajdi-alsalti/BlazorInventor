using System.ComponentModel.DataAnnotations;

namespace BlazorInventor.Model
{
    public class ControllerUiModel
    {
        public string Id { get; set; }
        public string ObjectIdentifer { get; set; }
        [Required]
        [StringLength(100,ErrorMessage ="Need to add controller name") ]
        public string Name { get; set; }

        [Required]
        [Range(50000, 60000, ErrorMessage = "Controller Number Begin at 50000")]
        public int Number { get; set; } = 50000;
    }
}
