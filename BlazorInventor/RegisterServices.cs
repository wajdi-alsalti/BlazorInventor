using DBInventorLibrary.DataAccess;
using DBInventorLibrary.DataAccess.Bands;
using DBInventorLibrary.DataAccess.Controllers;
using DBInventorLibrary.DataAccess.InventorData;
using DBInventorLibrary.DataAccess.InventorData.InventorMaterials;
using DBInventorLibrary.DataAccess.Materials;
using DBInventorLibrary.DataAccess.Wagens;
using DBInventorLibrary.DataAccessAbstract.Bands;
using DBInventorLibrary.DataAccessAbstract.Controllers;
using DBInventorLibrary.DataAccessAbstract.InventorData.Controllers;
using DBInventorLibrary.DataAccessAbstract.InventorData.Materials;
using DBInventorLibrary.DataAccessAbstract.Materilas;
using DBInventorLibrary.DataAccessAbstract.Services;
using DBInventorLibrary.DataAccessAbstract.Wagens;
using DBInventorLibrary.Models.Bands;
using DBInventorLibrary.Models.ControllerModels;
using DBInventorLibrary.Models.Inventor;
using DBInventorLibrary.Models.MaterialsModels;
using DBInventorLibrary.Models.WagensModel;

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


            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddSingleton<IBandsData, BandsData>();
            builder.Services.AddSingleton<IControllerData, ControllerData>();
            builder.Services.AddSingleton<IMaterialsData, MaterialsData>();
            builder.Services.AddSingleton<ISingleWagenData, SingleWagenData>();
            builder.Services.AddSingleton<IInventorControllerData, InventorControllerData>();
            builder.Services.AddSingleton<IInventorInformation, InventorInformation>();

            // test abstract class
            builder.Services.AddSingleton<IDataBase<BandsModel>, BandsAbstract>();
            builder.Services.AddSingleton<IDataBase<ControllerModel>, ControllersAbstract>();
            builder.Services.AddSingleton<IDataBase<MaterialsModel>, MaterialsAbstract>();
            builder.Services.AddSingleton<IDataBase<SingleWagenModel>, WagensAbstract>();
            builder.Services.AddSingleton<IDataBase<InventorModel>, InventorMaterialsDataAbstract>();
            builder.Services.AddSingleton<IDataBase<InventorControllers>, InventorControllersDataAbstract>();

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
