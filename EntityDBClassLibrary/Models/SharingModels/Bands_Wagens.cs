using EntityDBClassLibrary.Models.Bands;
using System.ComponentModel.DataAnnotations;

namespace EntityDBClassLibrary.Models.SharingModels
{
    public class Bands_Wagens
    {
        public int Id { get; set; }
        [Required]
        public BandsModel Band_Id { get; set; }
        [Required]
        public Wagen_Materials Wagen_Materials_Id { get; set; }
        public int WagenPosition { get; set; }
    }
}
