using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDBClassLibrary.Models.Wagen
{
    public class WagenModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName ="varchar(100)")]
        public string Name { get; set; }

    }
}
