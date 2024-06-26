using Microsoft.Extensions.Logging;
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Pages;
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterPages()
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

    }
}
