using WhatsOnTheMenu.Admin.Mobile.ViewModels;

namespace WhatsOnTheMenu.Admin.Mobile.Pages;

public partial class RecipePage : ContentPage
{
	public RecipePage(RecipeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}