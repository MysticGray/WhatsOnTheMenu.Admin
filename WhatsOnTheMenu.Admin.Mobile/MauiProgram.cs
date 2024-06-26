using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Pages;
using WhatsOnTheMenu.Admin.Mobile.Repository;
using WhatsOnTheMenu.Admin.Mobile.Services;
using WhatsOnTheMenu.Admin.Mobile.ViewModels;

namespace WhatsOnTheMenu.Admin.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterPages()
                .RegisterRepositories()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<RecipeListViewModel>();
            builder.Services.AddTransient<RecipeViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<RecipeListPage>();
            builder.Services.AddTransient<RecipePage>();
            builder.Services.AddTransient<PantryPage>();
            builder.Services.AddTransient<ShoppingListPage>();
            return builder;
        }

        private static MauiAppBuilder RegisterModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<Recipe>();
            return builder;
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5242"
                : "http://localhost:5242";
            builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
            builder.Services.AddHttpClient("WOTMApiClient",
                client =>
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                });
            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IRecipeService, RecipeService>();
            return builder;
        }

    }
}
