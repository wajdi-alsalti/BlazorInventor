using EntityDBClassLibrary.Models.Bands;
using EntityDBClassLibrary.Models.Materials;
using EntityDBClassLibrary.Models.SharingModels;
using EntityDBClassLibrary.Models.Wagen;
using Microsoft.EntityFrameworkCore;

namespace EntityDBClassLibrary
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<BandsModel> Bands { get; set; }
        public DbSet<MaterialsModel> Materials { get; set; }
        public DbSet<WagenModel> Wagens { get; set; }
        public DbSet<Wagen_Materials> Wagen_Materials { get; set; }
        public DbSet<Bands_Wagens> Bands_Wagens { get; set; }

    }
}
