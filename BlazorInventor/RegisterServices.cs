using DBInventorLibrary.DataAccessAbstract.Bands;
using DBInventorLibrary.DataAccessAbstract.Controllers;
using DBInventorLibrary.DataAccessAbstract.InventorData.Controllers;
using DBInventorLibrary.DataAccessAbstract.InventorData.Materials;
using DBInventorLibrary.DataAccessAbstract.Materilas;
using DBInventorLibrary.DataAccessAbstract.Wagens;

using DBInventorLibrary.Models.Bands;
using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.Inventor;
using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;
//using EntityDBClassLibrary;
//using Microsoft.EntityFrameworkCore;
using MongoDBConnectionClassLibrary.Data_Services;

namespace BlazorInventor
{
    public static class RegisterServices
    {
        public static RequestLocalizationOptions LocalizationOption { get; set; }
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMemoryCache();

            // Data Base library handel CRUD 
            builder.Services.AddSingleton<IDataAccessLibrary<BandsModel>, BandsAbstract>();
            builder.Services.AddSingleton<IDataAccessLibrary<ControllerModel>, ControllersAbstract>();
            builder.Services.AddSingleton<IDataAccessLibrary<MaterialsModel>, MaterialsAbstract>();
            builder.Services.AddSingleton<IDataAccessLibrary<SingleWagenModel>, WagensAbstract>();
            builder.Services.AddSingleton<IDataAccessLibrary<InventorModel>, InventorMaterialsDataAbstract>();
            builder.Services.AddSingleton<IDataAccessLibrary<InventorControllers>, InventorControllersDataAbstract>();

            // sql data base
            //builder.Services.AddDbContext<EFContext>(option => option.UseSqlServer(builder.Configuration.GetSection("SqlInfo").GetConnectionString("SQL")));
            // for localization

            builder.Services.AddControllers();
            // nav to the resources file for languages
            builder.Services.AddLocalization(option => option.ResourcesPath = "CultureLanguages");

            // red the cultures section from appsetting
            var culture = builder.Configuration.GetSection("Cultures")
                .GetChildren().ToDictionary(x => x.Key, x => x.Value);

            var supportedCulture = culture.Keys.ToArray();

            LocalizationOption = new RequestLocalizationOptions()
                // support for the different date styles from culture
                .AddSupportedCultures(supportedCulture)
                // this go to resources file and read the context
                .AddSupportedUICultures(supportedCulture);
        }
    }
}
