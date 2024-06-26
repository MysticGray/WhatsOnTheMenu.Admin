using WhatsOnTheMenu.Admin.Mobile.Pages;

namespace WhatsOnTheMenu.Admin.Mobile
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
            // Below code causing exception when using DI - 'No parameterless constructor defined for type 'WhatsOnTheMenu.Admin.Mobile.Pages.RecipeListPage'.'"
            // if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            //     Shell.Current.CurrentItem = PhoneTabs;

        }


    }
}
