using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityDBClassLibrary.Models.Materials
{
    public class MaterialsModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        public string Image { get; set; }

        [Required]
        public int SapNumber { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
