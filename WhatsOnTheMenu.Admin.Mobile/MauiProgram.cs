using Microsoft.Extensions.Logging;
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            var services = builder.Services;
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<HomePage> ();

            services.AddSingleton<RecipeListViewModel>();
            services.AddSingleton<RecipeListPage>();

            services.AddSingleton<RecipeViewModel>();
            services.AddSingleton<RecipePage>();
            return builder.Build();
        }
    }
}
