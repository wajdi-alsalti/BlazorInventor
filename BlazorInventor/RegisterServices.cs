﻿using DBInventorLibrary.DataAccess;

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
            builder.Services.AddSingleton<IWagensData, WagensData>();
            builder.Services.AddSingleton<ISingleWagenData, SingleWagenData>();


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
