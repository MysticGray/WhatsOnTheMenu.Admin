using WhatsOnTheMenu.Admin.Mobile.ViewModels;

namespace WhatsOnTheMenu.Admin.Mobile.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}