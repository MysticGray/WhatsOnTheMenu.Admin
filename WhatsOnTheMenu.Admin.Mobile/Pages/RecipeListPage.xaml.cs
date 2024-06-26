using WhatsOnTheMenu.Admin.Mobile.ViewModels;

namespace WhatsOnTheMenu.Admin.Mobile.Pages;

public partial class RecipeListPage : ContentPage
{
	public RecipeListPage(RecipeListViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}