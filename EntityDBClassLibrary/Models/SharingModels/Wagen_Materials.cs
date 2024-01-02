using EntityDBClassLibrary.Models.Materials;
using EntityDBClassLibrary.Models.Wagen;
using System.ComponentModel.DataAnnotations;

namespace EntityDBClassLibrary.Models.SharingModels
{
    public class Wagen_Materials
    {
        public int Id { get; set; }
        [Required]
        public WagenModel Wagen_Id { get; set; }
        [Required]
        public MaterialsModel Material_ID { get; set; }
    }
}
