
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WhatsOnTheMenu.Admin.Mobile.Models;
using WhatsOnTheMenu.Admin.Mobile.Pages;

namespace WhatsOnTheMenu.Admin.Mobile.ViewModels;

public partial class RecipeListViewModel : ObservableObject
{
    public List<Recipe> RecipeList { get; set; }
    [ObservableProperty]
    private RecipeViewModel _selectedRecipe;

    public RecipeListViewModel()
    {
        InitData();
    }

    private void InitData() 
    {
        RecipeList = new List<Recipe>
        {
            new Recipe
            { 
                Id = new Guid(),
                Name = "Cheese On Toast",
                ImageUrl = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/k%2FPhoto%2FRecipe%20Ramp%20Up%2F2022-05-Cheese-on-Toast%2FIMG_6699",
                RecipeSource = "Internet",
                Ingredients = new List<String>{"Cheese", "Bread"}
            },
            new Recipe
            {
                Id = new Guid(),
                Name = "Spaghetti",
                ImageUrl = "https://midwestfoodieblog.com/wp-content/uploads/2023/08/homemade-pasta-sauce-1.jpg",
                RecipeSource = "Internet",
                Ingredients = new List<String>{"Cheese", "Tomatoes", "Spaghetti" }
            }
        };
    }

    [RelayCommand]
    public async Task NavigateToSelectedItem()
    {
        await Shell.Current.GoToAsync(nameof(RecipePage));
    }

}
